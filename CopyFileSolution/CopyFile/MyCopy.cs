using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyFile
{
    public class MyCopy
    {
        public string SourceAddress { get; set; }
        public string DestinationAddress { get; set; }

        public void Copy()
        {
            using (FileStream reader = new FileStream(SourceAddress, FileMode.Open, FileAccess.Read))
            {
                using (FileStream writer = new FileStream(DestinationAddress, FileMode.Create, FileAccess.Write))
                {
                    byte[] block = new byte[1024 * 1024];
                    long fileSize = reader.Length;
                    double writtenSize = 0;
                    int blockSize = 0;

                    while ((blockSize = reader.Read(block, 0, block.Length)) > 0)
                    {
                        writtenSize += blockSize;
                        int progress = Convert.ToInt32(writtenSize / fileSize * 100);
                        writer.Write(block, 0, blockSize);
                    }
                }
            }
        }
    }
}
