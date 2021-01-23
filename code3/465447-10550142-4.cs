    // Get root directory
    string root = Server.MapPath("~");
    DirectoryInfo info = new DirectoryInfo(root);
    // Get all aspx files
    FileInfo[] files = info.GetFiles("*.aspx", SearchOption.AllDirectories);
    
    foreach (FileInfo fi in files)
    {
        // Get relative path
        string pageName = fi.FullName.Replace(root, "~/").Replace("\\", "/");
        // Add route
        routes.MapPageRoute(fi.Name + "Route", fi.Name.Replace(".aspx", ""), pageName);
    }
