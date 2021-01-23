    HttpContext.Current.Response.Clear();
    HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name); 
    HttpContext.Current.Response.ContentType = MIMETypesDictionary[fileExt];
    HttpContext.Current.Response.BinaryWrite(fileArray);
    HttpContext.Current.Response.End();
    HttpContext.Current.Response.Flush();
