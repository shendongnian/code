    string fileContent = Cache["SampleFile"] as string;
    if (string.IsNullOrEmpty(fileContent))
    {
        using (StreamReader sr = File.OpenText(Server.MapPath("~/SampleFile.txt")))
       {
           fileContent = sr.ReadToEnd();
           Cache.Insert("SampleFile", fileContent, new System.Web.Caching.CacheDependency(Server.MapPath("~/SampleFile.txt")));
       }
    }   
