    response.AddHeader("Content-Disposition", 
                        string.Format("attachment; filename = \"{0}\"",
                        System.IO.Path.GetFileName(FileName)));
    
    This is the right solution
