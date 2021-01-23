    public const string pageBreakHtmlMarker = "<!-- pageBreak -->";
    public MemoryStream htmlToPdf(string html)
    {
        MemoryStream msOutput = new MemoryStream();
        string[] sep = new string[] { pageBreakHtmlMarker };
        string[] arrHtml = html.Split(sep, 9999, StringSplitOptions.RemoveEmptyEntries);
        htmlToPdf(arrHtml, ref msOutput);
        return msOutput;
    }
    private void htmlToPdf(string[] arrHtmlPages, ref MemoryStream msOutput)
    {
        using (Document document = new Document(PageSize.A4, 30, 30, 30, 30))
        {
            using (HTMLWorker worker = new HTMLWorker(document))
            {
                PdfWriter writer = PdfWriter.GetInstance(document, msOutput); // writer to listen doc ad direct a XML-stream to a file            
                document.Open();
                worker.StartDocument();
                foreach (string html in arrHtmlPages)
                {
                    TextReader reader = new StringReader(html); // parse the html into the document
                    worker.Parse(reader);
                    document.Add(Chunk.NEXTPAGE);
                }
                worker.EndDocument();
            }
        }
    }
