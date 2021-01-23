    var doc = ...
    var contentDisposition = new ContentDisposition
    {
        FileName = doc.FileName,
        Inline = true
    };
    Response.AppendHeader("Content-Disposition", contentDisposition.ToString());
    
    return File(doc.Path, MediaTypeNames.Application.Pdf);
