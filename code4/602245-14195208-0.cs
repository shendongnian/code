      byte[] buffer = Generate();
      Response.ContentType = "application/pdf";
      Response.AddHeader("content-length", buffer.Length.ToString());
      Response.AppendHeader("Content-Disposition", "attachment; filename=youPDFName.pdf"); 
      Response.BinaryWrite(buffer);
      Response.End();
