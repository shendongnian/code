        public string ReadPdfFile(string fileName) {
            StringBuilder text = new StringBuilder();
            if (File.Exists(fileName)) {
                PdfReader pdfReader = new PdfReader(fileName);
                for (int page = 1; page <= pdfReader.NumberOfPages; page++) {
                    ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                    string currentText = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy);
                    text.Append(currentText);
                }
                pdfReader.Close();
            }
            return text.ToString();
        }
