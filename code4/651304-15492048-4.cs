    [WebMethod]
    public static List<string> GetFileListOnWebServer()
    {
       DirectoryInfo dInfo = new DirectoryInfo(HostingEnvironment.MapPath("~/UploadedFiles/"));
       FileInfo[] fInfo = dInfo.GetFiles("*.*", SearchOption.TopDirectoryOnly);
    
       List<string> listFilenames = new List<string>(fInfo.Length);
    
       for(int i = 0; i < fInfo.Length; i++)
       {
            listFilenames.Add(fInfo[i].Name);
       }
    
       return listFilenames;
    }
