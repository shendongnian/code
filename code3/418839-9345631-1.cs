        public static byte[] ConvertHtmlToPdf(string html)
        {
            html = HtmlPostProcessor.Process(html);
            byte[] fileData = null;
            int num = FontFactory.RegisterDirectory(@"C:\Windows\Fonts");
            
            using (MemoryStream ms = new MemoryStream(html.Length))
            {
                using (Document document = new Document(PageSize.LETTER, 50, 50, 50, 50))
                {
                    PdfWriter.GetInstance(document, ms);
                    using (StringReader stringReader = new StringReader(html))
                    {
                        List<IElement> parsedList = HTMLWorker.ParseToList(stringReader, null);
                        document.Open();
                        foreach (IElement item in parsedList)
                        {
                            document.Add(item);
                        }
                    }
                }
                fileData = ms.ToArray();
            }
            return fileData;
        }
