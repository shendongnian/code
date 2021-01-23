    public static void CreateBulkPdfFile(string[] fileNames, string outFile)
    {
      PdfCopyFields copier = new PdfCopyFields(new FileStream(outFile, FileMode.Create));
      int doc = 0;
      foreach (string filename in fileNames)
      {          
        PdfReader reader = new PdfReader(filename);
        // This should ensure field names are unique across merged documents
        foreach (var item in reader.AcroFields.Fields)
          reader.AcroFields.RenameField(item.ToString(), String.Format("_D{0}_{1}", doc++, item.ToString()));
        copier.AddDocument(reader);         
      }
      copier.Close();
    }
