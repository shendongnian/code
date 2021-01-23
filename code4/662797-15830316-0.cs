    using System;
    using System.IO;
    using System.IO.Compression;
    
    namespace zip
    {
        public class Program
        {
            public static void Main()
            {
                string directoryPath = @"c:\users\public\reports";
    
                DirectoryInfo directorySelected = new DirectoryInfo(directoryPath);
    
                foreach (FileInfo fileToCompress in directorySelected.GetFiles())
                {
                    Compress(fileToCompress);
                }
    
                foreach (FileInfo fileToDecompress in directorySelected.GetFiles("*.gz"))
                {
                    Decompress(fileToDecompress);
                }
            }
    
            public static void Compress(FileInfo fileToCompress)
            {
                using (FileStream originalFileStream = fileToCompress.OpenRead())
                {
                    if ((File.GetAttributes(fileToCompress.FullName) & FileAttributes.Hidden) != FileAttributes.Hidden & fileToCompress.Extension != ".gz")
                    {
                        using (FileStream compressedFileStream = File.Create(fileToCompress.FullName + ".gz"))
                        {
                            using (GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
                            {
                                originalFileStream.CopyTo(compressionStream);
                                Console.WriteLine("Compressed {0} from {1} to {2} bytes.",
                                    fileToCompress.Name, fileToCompress.Length.ToString(), compressedFileStream.Length.ToString());
                            }
                        }
                    }
                }
            }
    
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
                            decompressionStream.CopyTo(decompressedFileStream);
                            Console.WriteLine("Decompressed: {0}", fileToDecompress.Name);
                        }
                    }
                }
            }
        }
    }
