    using (MemoryStream memoryStream = new MemoryStream())
    {
        PdfStamper stamper = new PdfStamper(pdfReader, memoryStream);
        for (int i = 0; i <= pdfReader.XrefSize; i++)
        {
            PdfDictionary pd = pdfReader.GetPdfObject(i) as PdfDictionary;
            if (pd != null)
            {
                pd.Remove(PdfName.AA); // Removes automatic execution objects
                pd.Remove(PdfName.JS); // Removes javascript objects
                pd.Remove(PdfName.JAVASCRIPT); // Removes other javascript objects
            }
        }
        stamper.Close();
        pdfReader.Close();
        File.WriteAllBytes(rawfile, memoryStream.ToArray());
    }
