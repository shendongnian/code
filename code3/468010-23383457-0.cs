    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace CompressFile
    {
        class Program
        {
    
    
            static void Main(string[] args)
            {
                string FileToCompress = @"D:\Program Files (x86)\msvc\wkhtmltopdf64\bin\wkhtmltox64.dll";
                FileToCompress = @"D:\Program Files (x86)\msvc\wkhtmltopdf32\bin\wkhtmltox32.dll";
                string CompressedFile = System.IO.Path.Combine(
                     System.IO.Path.GetDirectoryName(FileToCompress)
                    ,System.IO.Path.GetFileName(FileToCompress) + ".gz"
                );
    
    
                CompressFile(FileToCompress, CompressedFile);
                // CompressFile_AllInOne(FileToCompress, CompressedFile);
    
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine(" --- Press any key to continue --- ");
                Console.ReadKey();
            } // End Sub Main
    
    
            public static void CompressFile(string FileToCompress, string CompressedFile)
            {
                //byte[] buffer = new byte[1024 * 1024 * 64];
                byte[] buffer = new byte[1024 * 1024]; // 1MB
    
                using (System.IO.FileStream sourceFile = System.IO.File.OpenRead(FileToCompress))
                {
    
                    using (System.IO.FileStream destinationFile = System.IO.File.Create(CompressedFile))
                    {
    
                        using (System.IO.Compression.GZipStream output = new System.IO.Compression.GZipStream(destinationFile,
                            System.IO.Compression.CompressionMode.Compress))
                        {
                            int bytesRead = 0;
                            while (bytesRead < sourceFile.Length)
                            {
                                int ReadLength = sourceFile.Read(buffer, 0, buffer.Length);
                                output.Write(buffer, 0, ReadLength);
                                output.Flush();
                                bytesRead += ReadLength;
                            } // Whend
    
                            destinationFile.Flush();
                        } // End Using System.IO.Compression.GZipStream output
    
                        destinationFile.Close();
                    } // End Using System.IO.FileStream destinationFile 
    
                    // Close the files.
                    sourceFile.Close();
                } // End Using System.IO.FileStream sourceFile
    
            } // End Sub CompressFile
    
    
            public static void CompressFile_AllInOne(string FileToCompress, string CompressedFile)
            {
                using (System.IO.FileStream sourceFile = System.IO.File.OpenRead(FileToCompress))
                {
                    using (System.IO.FileStream destinationFile = System.IO.File.Create(CompressedFile))
                    {
    
                        byte[] buffer = new byte[sourceFile.Length];
                        sourceFile.Read(buffer, 0, buffer.Length);
    
                        using (System.IO.Compression.GZipStream output = new System.IO.Compression.GZipStream(destinationFile,
                            System.IO.Compression.CompressionMode.Compress))
                        {
                            output.Write(buffer, 0, buffer.Length);
                            output.Flush();
                            destinationFile.Flush();
                        } // End Using System.IO.Compression.GZipStream output
    
                        // Close the files.        
                        destinationFile.Close();
                    } // End Using System.IO.FileStream destinationFile 
    
                    sourceFile.Close();
                } // End Using System.IO.FileStream sourceFile
    
            } // End Sub CompressFile
    
    
        } // End Class Program
    
    
    } // End Namespace CompressFile
