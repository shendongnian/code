    Document doc = new Document();
    StyleSheet styles = new StyleSheet();
    string filePath = @"Z:\programs\" + pdfName + ".pdf";
    using (FileStream pdfStream = new FileStream(filePath, FileMode.Create))
    {
        using (PdfWriter writer = PdfWriter.GetInstance(doc, pdfStream))
        {
            writer.CloseStream = false;
            doc.Open();
            doc.OpenDocument();
            doc.NewPage();
            if (doc.IsOpen() == true)
            {
                using (StringReader reader = new StringReader(html))
                {
                    //XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, reader);
                    doc.Add(new Paragraph(" "));
                    using (HTMLWorker worker = new HTMLWorker(doc))
                    {
                        worker.Open();
                        worker.StartDocument();
                        worker.NewPage();
                        worker.Parse(reader);
                        worker.SetStyleSheet(styles);
                        List<IElement> ie = iTextSharp.text.html.simpleparser.HTMLWorker.ParseToList(reader, null);
                        foreach (IElement element in ie)
                        {
                            doc.Add((IElement)element);
                        }
                        worker.EndDocument();
                        worker.Close();
                    }
                }
            }
            writer.Close();
        }
    }
    doc.CloseDocument();
    doc.Close();
    doc.Dispose(); 
