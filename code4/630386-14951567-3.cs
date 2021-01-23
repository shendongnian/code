    /**
     * Extracts document level attachments
     * @param PDF from which document level attachments will be extracted
     * @param zip the ZipFile object to add the extracted images
     */
    public void ExtractDocLevelAttachments(byte[] pdf, ZipFile zip) {
      PdfReader reader = new PdfReader(pdf);
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
          zip.AddEntry(
            filespec.GetAsString(key).ToString(), 
            PdfReader.GetStreamBytes(stream)
          );
        }
      }
    }
