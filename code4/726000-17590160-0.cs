    public byte[] ManipulatePdf(byte[] src, byte[] stationery)
    {
      // Create readers
      PdfReader reader = new PdfReader(src);
      PdfReader s_reader = new PdfReader(stationery);
      using (MemoryStream ms = new MemoryStream())
      {
        // Create the stamper
        using (PdfStamper stamper = new PdfStamper(reader, ms))
        {
          // Add the stationery to each page
          PdfImportedPage page = stamper.GetImportedPage(s_reader, 1);
          int n = reader.NumberOfPages;
          PdfContentByte background;
          for (int i = 1; i <= n; i++)
          {
            background = stamper.GetUnderContent(i);
            background.AddTemplate(page, 0, 0);
          }
        } 
        return ms.ToArray();   
      }
    }  
