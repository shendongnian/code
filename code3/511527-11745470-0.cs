    if (inline)
    {
       Response.ClearHeaders();
    
    Response.AppendHeader("Content-Disposition", string.Format("inline; filename={0}", PDFFile));
    Response.BufferOutput = true;
    return File(PDFStream, MediaTypeNames.Application.Pdf);
    }
    else
    return File(PDFStream, MediaTypeNames.Application.Pdf, PDFFile);
