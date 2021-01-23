    //We'll use this byte array as an intermediary later
    Byte[] bytes;
    //Basic setup for iTextSharp to write to a MemoryStream, nothing special
    using (var ms = new MemoryStream()) {
        using (var document = new Document()) {
            using (var writer = PdfWriter.GetInstance(document, ms)) {
                document.Open();
                //Create our HTML worker (deprecated by the way)
                HTMLWorker htmlworker = new HTMLWorker(document);
                //Render our control
                using (var stw = new StringWriter()) {
                    using (var htextw = new HtmlTextWriter(stw)) {
                        GridView1.RenderControl(htextw);
                    }
                    using (var str = new StringReader(stw.ToString())) {
                        htmlworker.Parse(str);
                    }
                }
                //Close the PDF
                document.Close();
            }
        }
        //Get the raw bytes of the PDF
        bytes = ms.ToArray();
    }
    //At this point all PDF work is complete and we only have to deal with the raw bytes themselves
    string attachment = "attachment; filename=Article.pdf";
    Response.ClearContent();
    Response.AddHeader("content-disposition", attachment);
    Response.ContentType = "application/pdf";
    Response.BinaryWrite(bytes);
    Response.End();
