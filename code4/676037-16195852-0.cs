    Response.Clear();
    Response.ClearHeaders();
    Response.ClearContent();
    Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
    Response.AddHeader("Content-Length", file.Length.ToString());
    Response.ContentType = "application/pdf";
    Response.Flush();
    Response.TransmitFile(file.FullName);
    Response.End();
