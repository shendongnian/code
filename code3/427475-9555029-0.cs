      using (ZipFile zip = ZipFile.Read(ExistingZipFile))
      {
        foreach (ZipEntry e in zip)
        {
          System.Console.WriteLine("{1,-22} {2,8} {3,5:F0}%   {4,8}  {5,3} {0}",
                                   e.FileName,
                                   e.LastModified.ToString("yyyy-MM-dd HH:mm:ss"),
                                   e.UncompressedSize,
                                   e.CompressionRatio,
                                   e.CompressedSize,
                                   (e.UsesEncryption) ? "Y" : "N");
        }
      }
