    PdfReader reader = new PdfReader(pdfPath);
    PdfReaderContentParser parser = new PdfReaderContentParser(reader);
    StringBuilder sb = new StringBuilder();
    for (int i = 1; i <= reader.NumberOfPages; i++) {
      ITextExtractionStrategy strategy = parser.ProcessContent(
        i, new SimpleTextExtractionStrategy()
      );
      sb.Append(strategy.GetResultantText());
    }
