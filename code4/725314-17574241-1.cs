    public ArrayList GetImage()
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(HttpContext.Current.Server.MapPath("~/Layout/Images/Banner"));
        ArrayList arrayList = new ArrayList();
        foreach (FileInfo fi in directoryInfo.GetFiles())
                arrayList.Add(fi.FullName);
        return arrayList;
    }
