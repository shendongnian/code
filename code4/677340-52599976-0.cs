    using(TextFieldParser parser = new TextFieldParser(new StringReader(csv))) {
     parser.Delimiters = new [] {","};
    
     while (!parser.EndOfData) {
      string[] fields = null;
      try {
       fields = parser.ReadFields();
      } catch (MalformedLineException ex) {
       string errorLine = SafeTrim(parser.ErrorLine);
       fields = errorLine.Split(',');
      }
     }
    }
