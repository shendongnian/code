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
   
                               
