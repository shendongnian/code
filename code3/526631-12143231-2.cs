        public static void Compress(FileInfo fileToCompress)
        {
            using (FileStream originalFileStream = fileToCompress.OpenRead())
            {
                using (FileStream compressedFileStream = File.Create(fileToCompress.FullName + ".gz"))
                {
                   using (GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
                   {
                          originalFileStream.CopyTo(compressionStream);                                
                   }
                }
            }
        }
