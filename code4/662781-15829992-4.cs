    MemoryStream memoryStream = null;
    try
    {
      memoryStream = new MemoryStream();
      using (PdfStamper pdfStamper = new PdfStamper(pdfReader, memoryStream))
      {
        memoryStream = null;
        var fields = pdfStamper.AcroFields;
        fields.SetField("CityName", "It works!");
        pdfReader.Close();
        pdfStamper.FormFlattening = true;
        pdfStamper.FreeTextFlattening = true;
        pdfStamper.Close();
        return memoryStream.ToArray();
      }
    }
    finally
    {
      if (memoryStream != null) memoryStream.Dispose();
    }
    
