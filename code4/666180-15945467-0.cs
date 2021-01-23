    byte[] mergedPdf = null;
    using (MemoryStream ms = new MemoryStream())
    {
        using (Document document = new Document())
        {
            using (PdfCopy copy = new PdfCopy(document, ms))
            {
                document.Open();
                for (int i = 0; i < pdf.Count; ++i)
                {
                    PdfReader reader = new PdfReader(pdf[i]);
                    // loop over the pages in that document
                    int n = reader.NumberOfPages;
                    for (int page = 0; page < n; )
                    {
                        copy.AddPage(copy.GetImportedPage(reader, ++page));
                    }
                }
            }
        }
        mergedPdf = ms.ToArray();
    }
