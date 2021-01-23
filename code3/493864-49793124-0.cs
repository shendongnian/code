    string str = "Page1Page1Page1Page1Page1Page1Page1Page1Page1Page1";
        string str2 = "Page2Page2Page2Page2Page2Page2Page2Page2Page2Page2";
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        using (var htmlWorker = new HTMLWokExtend(pdfDoc))
        {
           using (var sr = new StringReader(str))
            {
                htmlWorker.Parse(sr);
            }
        }
        pdfDoc.NewPage();
        using (var htmlWorker = new HTMLWokExtend(pdfDoc))
        {
           using (var sr = new StringReader(str2))
            {
              htmlWorker.Parse(sr);
            }
        }
    pdfDoc.Close();
    Response.ContentType = "application/pdf";
    Response.AddHeader("content-disposition", "attachment;" +
                                   "filename=Proforma_Invoice.pdf");
    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    Response.Write(pdfDoc);
    Response.End();
