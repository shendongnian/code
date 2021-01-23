    public static Stream ZipGenerator(List<string> files)
        {
            ZipArchiveEntry fileInArchive;
            Stream entryStream;
            int i = 0;
            List<byte[]> byteArray = new List<byte[]>();
            foreach (var file in files)
            {
                byteArray.Add(File.ReadAllBytes(file));
            }
            var outStream = new MemoryStream();
            
            using (var archive = new ZipArchive(outStream, ZipArchiveMode.Create, true))
            {
                foreach (var file in files)
                {
                    fileInArchive=(archive.CreateEntry(Path.GetFileName(file), CompressionLevel.Optimal));
 
                    using (entryStream = fileInArchive.Open())
                    {
                            using (var fileToCompressStream = new MemoryStream(byteArray[i]))
                            {
                                fileToCompressStream.CopyTo(entryStream);
                            }
                            i++;
                    }
                }
            }
            outStream.Position = 0;
            return outStream;
        }
