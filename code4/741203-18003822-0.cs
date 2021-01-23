    using(Stream t = template.OpenBinaryStream())
    {
        using (WordprocessingDocument myDoc = WordprocessingDocument.Open(t, true))
        {
            using (XmlWriter writer = XmlWriter.Create(resp.OutputStream))
            {
                // TODO re-add merge logic here once it works
                HttpResponse resp = HttpContext.Current.Response;
                resp.ClearContent();
                resp.ClearHeaders();
                resp.AddHeader("Content-Disposition", 
                    "attachment; filename=Assembled Document.docx");
                //resp.ContentEncoding = System.Text.Encoding.UTF8;
                resp.ContentType = "application/msword";
                // resp.OutputStream.Write(mem.ToArray(), 0, (int)mem.Length);
    /* new */   myDoc.MainDocumentPart.Document.WriteTo(writer);
                resp.Flush();
                resp.Close();
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
        }
    }
