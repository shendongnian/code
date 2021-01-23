      public static string ReadPdfFile(string fileName)
      {
          StringBuilder text = new StringBuilder();
          if (File.Exists(fileName))
          {
              PdfReader pdfReader = new PdfReader(fileName);
              for (int page = 1; page <= pdfReader.NumberOfPages; page++)
              {
                  ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                  string currentText = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy);
                  currentText = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(currentText)));
                  text.Append(currentText);
              }
              pdfReader.Close();
          }
          return text.ToString();
      }
From there you can simply run some REGEX to get the column using the pattern you laid out:
    string text = ReadPdfFile(@"path\to\pdf\file.pdf");
    Regex regex = new Regex(@"(?<number>\d{15})");
    List<string> results = new List<string>();
    foreach (Match m in regex.Matches(text))
    {
        results.Add(m.Groups["number"].Value);
    }
