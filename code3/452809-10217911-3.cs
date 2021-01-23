            System.IO.MemoryStream stream = (System.IO.MemoryStream)doc.ExportToStream(ExportFormatType.PortableDocFormat);
            Response.ClearHeaders();
            Response.ClearContent();
            Response.ContentType="application/pdf";
            stream.CopyTo(Response.OutputStream);
            Response.Flush();
