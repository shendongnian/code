    public byte[] Render(string htmlText, string pageTitle)
    {
        byte[] renderedBuffer;
    
        using (var outputMemoryStream = new MemoryStream())
        {
            using (var pdfDocument = new Document(PageSize.A4, HorizontalMargin, HorizontalMargin, VerticalMargin, VerticalMargin))
            {
                string arialuniTff = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIALUNI.TTF");
                iTextSharp.text.FontFactory.Register(arialuniTff);
    
                PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDocument, outputMemoryStream);
    
                pdfWriter.CloseStream = false;
                pdfWriter.PageEvent = new PrintHeaderFooter { Title = pageTitle };
                pdfDocument.Open();
    
                using (var htmlViewReader = new StringReader(htmlText))
                {
                    using (var htmlWorker = new HTMLWorker(pdfDocument))
                    {
                        var styleSheet = new iTextSharp.text.html.simpleparser.StyleSheet();
                        styleSheet.LoadTagStyle(HtmlTags.BODY, HtmlTags.FACE, "Arial Unicode MS");
                        styleSheet.LoadTagStyle(HtmlTags.BODY, HtmlTags.ENCODING, BaseFont.IDENTITY_H);
                        htmlWorker.SetStyleSheet(styleSheet);
    
                        htmlWorker.Parse(htmlViewReader);
                    }
                }
            }
    
            renderedBuffer = new byte[outputMemoryStream.Position];
            outputMemoryStream.Position = 0;
            outputMemoryStream.Read(renderedBuffer, 0, renderedBuffer.Length);
        }
    
        return renderedBuffer;
    }
