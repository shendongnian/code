    // add any string you want to match on
    Regex regex = new Regex("the", 
      RegexOptions.IgnoreCase | RegexOptions.Compiled 
    );
    PdfReader reader = new PdfReader(pdfPath);
    PdfReaderContentParser parser = new PdfReaderContentParser(reader);
    for (int i = 1; i <= reader.NumberOfPages; i++) {
      ITextExtractionStrategy strategy = parser.ProcessContent(
        i, new SimpleTextExtractionStrategy()
      );
      if ( regex.IsMatch(strategy.GetResultantText()) ) {
        // do whatever with corresponding page number i...
      }
    }
