    PdfReader reader = new PdfReader(readerPath);
    PdfDictionary root = reader.Catalog;
    PdfDictionary documentnames = root.GetAsDict(PdfName.NAMES);
    PdfDictionary embeddedfiles = 
        documentnames.GetAsDict(PdfName.EMBEDDEDFILES);
    PdfArray filespecs = embeddedfiles.GetAsArray(PdfName.NAMES);
    for (int i = 0; i < filespecs.Size; ) {
      filespecs.GetAsString(i++);
      PdfDictionary filespec = filespecs.GetAsDict(i++);
      PdfDictionary refs = filespec.GetAsDict(PdfName.EF);
      foreach (PdfName key in refs.Keys) {
        PRStream stream = (PRStream) PdfReader.GetPdfObject(
          refs.GetAsIndirectObject(key)
        );
        
        using (FileStream fs = new FileStream(
          filespec.GetAsString(key).ToString(), FileMode.OpenOrCreate
        )){
          byte[] attachment = PdfReader.GetStreamBytes(stream);
          fs.Write(attachment, 0, attachment.Length);
        }
      }
    } 
