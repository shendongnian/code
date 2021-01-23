    //using System.Linq
    protected void getFiles()
    {
        System.Text.StringBuilder sbld = new System.Text.StringBuilder();
        if (Directory.Exists(Server.MapPath("~/Package_Image/")))
        {
            DirectoryInfo dirMail = new DirectoryInfo(Server.MapPath("~/Package_Image/"));
            FileInfo[] orig = dirMail.GetFiles();        
            // Sort on server
            FileInfo[] DefaultFiles = (from file in orig orderby file.CreationTime select file).ToArray();
            foreach (FileInfo fileDir in DefaultFiles)
            {
                if (fileDir.Extension.ToLower() == ".jpg" || fileDir.Extension.ToLower() == ".gif" || fileDir.Extension.ToLower() == ".png" || fileDir.Extension.ToLower() == ".jpeg" || fileDir.Extension.ToLower() == ".bmp")
                {
                    // need sorting on the basis of date-time, it was created or uploaded.
                    sbld.Append("<div class='itemBox'><table width='100%'><tr><td height='160'><img width='200' src='../Package_Image/" + fileDir.Name + "'></img></td></tr></table></div>");
                }
            }
            Literal1.Text = (sbld.ToString());
        }
    }
