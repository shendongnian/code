    // step 1
    using (Document document = new Document(PageSize.A4, 36, 36, 54, 36)) {
      // step 2
      PdfWriter writer = PdfWriter.GetInstance(document, stream);
      TableHeader tevent = new TableHeader();
      writer.PageEvent = tevent;
      // step 3
      document.Open();
      [...]
    }
