        public class CacheHelper
        {
            private const int kMaxFileSize = 8000000;
            private readonly int fFileSize;
            private readonly string fFileName;
            public CacheHelper(int sizeOfFile, string nameOfFile)
            {
                fFileSize = sizeOfFile;
                fFileName = nameOfFile;
            }
    
            public CachingObjectHolder Split(byte[] file)
            {
                var remainingSize = file.Length;
                var partialList = new List<byte[]>();
                var partial = new byte[file.Length > kMaxFileSize ? kMaxFileSize : file.Length];
                for (int i = 0; i < file.Length; i++)
                {
                    if (i % kMaxFileSize == 0 && i > 0)
                    {
                        partialList.Add(partial);
                        partial = new byte[remainingSize > kMaxFileSize ? kMaxFileSize : remainingSize];
                    }
    
                    partial[i % kMaxFileSize] = file[i];
                    remainingSize--;
                }
    
                partialList.Add(partial);
    
                return new CachingObjectHolder(fFileName, partialList);
            }
    
            public static byte[] Join(CachingObjectHolder cachingObjectHolder)
            {
                var totalByteSize = cachingObjectHolder.Partials.Sum(x => x.Length);
                var output = new byte[totalByteSize];
                var globalCounter = 0;
                for (int i = 0; i < cachingObjectHolder.Partials.Count; i++)
                {
                    for (int j = 0; j < cachingObjectHolder.Partials[i].Length; j++)
                    {
                        output[globalCounter] = cachingObjectHolder.Partials[i][j];
                        globalCounter++;
                    }
                }
    
                return output;
            }
    
            public static byte[] CreateFile(int size)
            {
                var tempFile = Path.GetTempFileName();
                using (var stream = new FileStream(tempFile, FileMode.OpenOrCreate))
                {
                    using (var memStream = new MemoryStream())
                    {
                        stream.SetLength(size);
                        stream.CopyTo(memStream);
                        return memStream.ToArray();
                    }
                }
            }
        }
