    var cd = new System.Net.Mime.ContentDisposition
    {
        FileName = "Export.txt", 
        Inline = false, 
    };
    Response.AppendHeader("Content-Disposition", cd.ToString());
    return File(file, "text/plain");
