    if (file.ContentLength > 0)
    {
        var fileName = Path.GetFileName(file.FileName);
        var fullpath = System.Web.HttpContext.Current.Server.MapPath("~/Content/Documents");
    
        //deleting code starts here
        string[] files = System.IO.Directory.GetFiles(fullpath,"document.*");
        foreach (string f in files)
        {
           System.IO.File.Delete(f);
        }
        //deleting code ends here
        file.SaveAs(Path.Combine(fullpath,"document"+Path.GetExtension(fileName)));
    }
