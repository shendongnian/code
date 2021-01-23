        Response.Buffer = true;
                Response.Clear();
                Response.ClearContent();
                Response.ClearHeaders();
                Response.ContentType = "application/pdf";
                Response.AddHeader(
                  "Content-Disposition",
                  string.Format("attachment; filename={0}",filename)
                );
                // stream pdf bytes to the browser
                Response.OutputStream.Write(estatement.Document, 0, estatement.Document.Length);
                Response.End();
