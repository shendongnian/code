    int ik = 1;
    string folderpath = @"C:\Users\Nouser\Documents\Visual Studio 2010\WebSites\folders";
    string foldername = TextBox1.Text;
    string newPath = System.IO.Path.Combine(folderpath, foldername);
    while (Directory.Exists(newPath))
    {
        newPath = System.IO.Path.Combine(folderpath, foldername + ik);
        ik = ik + 1;
    }
    System.IO.Directory.CreateDirectory(newPath);
