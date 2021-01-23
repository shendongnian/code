    protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["dir"] != null)
            {
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Path.Combine("c:\\", Request.Params["dir"]));
                if (di.Exists)
                {
                    DirectoryInfo[] directories = di.GetDirectories("*.*", SearchOption.TopDirectoryOnly);
                    Response.Write("<ul class=\"jqueryFileTree\" >\n");
                    //Itera sobre os subdiretórios de cada driver
                    foreach (System.IO.DirectoryInfo di_child in directories)
                    {
                        Response.Write("\t<li class=\"directory collapsed\"><a href=\"#\" rel=\"" + di_child.Name + "/\">" + di_child.Name + "</a>\n");
                    }
                    foreach (System.IO.FileInfo fi in di.GetFiles())
                    {
                        string ext = "";
                        if (fi.Extension.Length > 1)
                        {
                            ext = fi.Extension.Substring(1).ToLower();
                        }
                        Response.Write("\t<li class=\"file ext_" + ext + "\"><a href=\"#\" rel=\"" + fi.Name + "\">" + fi.Name + "</a></li>\n");
                    }// Arquivos 
                    Response.Write("</ul></li>");
                }
            }
        }
