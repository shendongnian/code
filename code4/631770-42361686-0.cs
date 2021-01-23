    protected void Page_Load(object sender, EventArgs e) {
        
        itemWrapper.InnerHtml = GetDirectory(Request.QueryString["path"]);
    }
    
    static string GetDirectory(string path)
    {
        StringBuilder output = new StringBuilder();
        var subdir = System.IO.Directory.GetDirectories(path);
        var files = System.IO.Directory.GetFiles(path);
        output.Append("<ul><li><a>");
        output.Append(path.Replace("_", " "));
        output.Append(subdir.Length > 0 || files.Length > 0 ? "+</a>" : "</a>");
                
        foreach(var sb in subdir)
        {
            output.Append(GetDirectory(sb));
        }
    
        if (files.Length > 0)
        {
            output.Append("<ul>");
            foreach (var file in files)
            {
                output.AppendFormat("<li><a href =\"{0}\">{1}</a></li>", file, System.IO.Path.GetFileName(file));
            }
            output.Append("</ul>");
        }
        output.Append("</ul>");
        return output.ToString();
    }
