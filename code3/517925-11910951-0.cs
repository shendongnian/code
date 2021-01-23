    string filenameA = HttpContext.Current.Server.MapPath("~\\Scripts\\File1.js"));
    string filenameB = HttpContext.Current.Server.MapPath("~\\Scripts\\File2.js"));
    string fileContentA = File.ReadAllText(filenameA);
    string fileContentB - Flie.ReadAllText(filenameB);
    System.IO.File.WriteAllText("filename", fileContentA + "\n" + fileContentB);
