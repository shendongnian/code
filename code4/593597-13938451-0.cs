            public static void Decompress(FileInfo fileToDecompress)
        {
            using (FileStream originalFileStream = fileToDecompress.OpenRead())
            {
                string currentFileName = fileToDecompress.FullName;
                string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);
                using (FileStream decompressedFileStream = File.Create(newFileName))
                {
                    using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                        MemoryStream memStream = new MemoryStream();
                        //memStream.SetLength(decompressedFileStream.Length); not necessary
                        decompressionStream.CopyTo(memStream);
                        memStream.Seek(0, SeekOrigin.Begin);
                        var sr = new StreamReader(memStream);
                        var myStr = sr.ReadToEnd();
                        Console.WriteLine("Stream Output: " + myStr);
                    }
                }
            }
        }
