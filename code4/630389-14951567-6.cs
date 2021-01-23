    /**
     * Extracts attachments from an existing PDF.
     * @param src the path to the existing PDF
     * @param zip the ZipFile object to add the extracted images
     */
    public void ExtractAttachments(byte[] src, ZipFile zip) {
      PdfReader reader = new PdfReader(src);
      for (int i = 1; i <= reader.NumberOfPages; i++) {
        PdfArray array = reader.GetPageN(i).GetAsArray(PdfName.ANNOTS);
        if (array == null) continue;
        for (int j = 0; j < array.Size; j++) {
          PdfDictionary annot = array.GetAsDict(j);
          if (PdfName.FILEATTACHMENT.Equals(
              annot.GetAsName(PdfName.SUBTYPE)))
          {
            PdfDictionary fs = annot.GetAsDict(PdfName.FS);
            PdfDictionary refs = fs.GetAsDict(PdfName.EF);
            foreach (PdfName name in refs.Keys) {
              zip.AddEntry(
                fs.GetAsString(name).ToString(), 
                PdfReader.GetStreamBytes((PRStream)refs.GetAsStream(name))
              );
            }
          }
        }
      }
    }
