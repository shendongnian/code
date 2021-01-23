.NET 2.0.
    public static void CompressFile(string path)
    {
        FileStream sourceFile = File.OpenRead(path);
        FileStream destinationFile = File.Create(path + ".gz");
        byte[] buffer = new byte[sourceFile.Length];
        sourceFile.Read(buffer, 0, buffer.Length);
        using (GZipStream output = new GZipStream(destinationFile,
            CompressionMode.Compress))
        {
            Console.WriteLine("Compressing {0} to {1}.", sourceFile.Name,
                destinationFile.Name, false);
            output.Write(buffer, 0, buffer.Length);
        }
        // Close the files.
        sourceFile.Close();
        destinationFile.Close();
    }
.NET 4
    public static void Compress(FileInfo fi)
        {
            // Get the stream of the source file.
            using (FileStream inFile = fi.OpenRead())
            {
                // Prevent compressing hidden and 
                // already compressed files.
                if ((File.GetAttributes(fi.FullName) 
                	& FileAttributes.Hidden)
                	!= FileAttributes.Hidden & fi.Extension != ".gz")
                {
                    // Create the compressed file.
                    using (FileStream outFile = 
                    			File.Create(fi.FullName + ".gz"))
                    {
                        using (GZipStream Compress = 
                        	new GZipStream(outFile, 
                        	CompressionMode.Compress))
                        {
                            // Copy the source file into 
                            // the compression stream.
                        inFile.CopyTo(Compress);
                            Console.WriteLine("Compressed {0} from {1} to {2} bytes.",
                                fi.Name, fi.Length.ToString(), outFile.Length.ToString());
                        }
                    }
                }
            }
        }
