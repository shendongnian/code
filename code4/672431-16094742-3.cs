    public ActionResult Download()
    {
        var document = ...
        var cd = new System.Net.Mime.ContentDisposition
        {
            // for example foo.bak
            FileName = document.FileName, 
    
            // always prompt the user for downloading, set to true if you want 
            // the browser to try to show the file inline
            Inline = false, 
        };
        Response.AppendHeader("Content-Disposition", cd.ToString());
        return File(document.Data, document.ContentType);
    }
