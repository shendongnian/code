    using (ZipOutputStream zipStream = new ZipOutputStream(File.Create(zipFilePath)))
    {
     //Compression level 0-9 (9 is highest)
     zipStream.SetLevel(GetCompressionLevel());
    
     //Add an entry to our zip file
     ZipEntry entry = new ZipEntry(Path.GetFileName(sourceFilePath));
     entry.DateTime = DateTime.Now;
     /* 
     * By specifying a size, SharpZipLib will turn on/off UseZip64 based on the file sizes. If Zip64 is ON
     * some legacy zip utilities (ie. Windows XP) who can't read Zip64 will be unable to unpack the archive.
     * If Zip64 is OFF, zip archives will be unable to support files larger than 4GB.
     */
     entry.Size = new FileInfo(sourceFilePath).Length;
     zipStream.PutNextEntry(entry);
    
     byte[] buffer = new byte[4096];
     int byteCount = 0;
    
     using (FileStream inputStream = File.OpenRead(sourceFilePath))
     {
         byteCount = inputStream.Read(buffer, 0, buffer.Length);
         while (byteCount > 0)
         {
             zipStream.Write(buffer, 0, byteCount);
             byteCount = inputStream.Read(buffer, 0, buffer.Length);
         }
     }
    }
