    using (ZipFile zip = ZipFile.Read(ExistingZipFile))
    {
      foreach (ZipEntry ze in zip)
      {
        if (header)
        {
          System.Console.WriteLine("Zipfile: {0}", zip.Name);
          if ((zip.Comment != null) && (zip.Comment != "")) 
            System.Console.WriteLine("Comment: {0}", zip.Comment);
          System.Console.WriteLine("\n{1,-22} {2,8}  {3,5}   {4,8}  {5,3} {0}",
                                   "Filename", "Modified", "Size", "Ratio", "Packed", "pw?");
          System.Console.WriteLine(new System.String('-', 72));
          header = false;
        }
        System.Console.WriteLine("{1,-22} {2,8} {3,5:F0}%   {4,8}  {5,3} {0}",
                                 ze.FileName,
                                 ze.LastModified.ToString("yyyy-MM-dd HH:mm:ss"),
                                 ze.UncompressedSize,
                                 ze.CompressionRatio,
                                 ze.CompressedSize,
                                 (ze.UsesEncryption) ? "Y" : "N");
    
      }
    }
