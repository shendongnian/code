        /// <summary>
        /// Read a PDF file and returns the string content.
        /// </summary>
        /// <param name="par">ByteArray, MemoryStream or URI</param>
        /// <returns>FileContent.</returns>
        public static string ReadPdfFile(object par)
        {
            if (par == null) throw new ArgumentNullException("par");
            PdfReader pdfReader = null;
            var text = new StringBuilder();
            if (par is MemoryStream)
                pdfReader = new PdfReader((MemoryStream)par);
            else if (par is byte[])
                pdfReader = new PdfReader((byte[])par);
            else if (par is Uri)
                pdfReader = new PdfReader((Uri)par);
            if (pdfReader == null)
                throw new InvalidOperationException("Unable to read the file.");
            for (var page = 1; page <= pdfReader.NumberOfPages; page++)
            {
                var strategy = new SimpleTextExtractionStrategy();
                var currentText = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy);
                currentText = Encoding.UTF8.GetString(Encoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(currentText)));
                text.Append(currentText);
            }
            pdfReader.Close();
            return text.ToString();
        }
