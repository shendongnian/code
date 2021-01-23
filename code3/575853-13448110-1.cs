     protected void Page_Load(object sender, EventArgs e)
        {
            string path = HttpContext.Current.Request.PhysicalApplicationPath + @"\Images\Temple";
            // string path = @"D:\Blog\ImageShow\Images"; // This statement also valid
            string[] extensions = { "*.jpg", "*.png", "*.bmp" };
            List<string> files = new List<string>();
            foreach (string filter in extensions)
            {
                files.AddRange(System.IO.Directory.GetFiles(path, filter));
            }
            IList<ImageFileInfo> imageFileList = new List<ImageFileInfo>();
            foreach (string strFileName in files)
            {
                // Change the Absolute path to relative path of File Name and add to the List
                imageFileList.Add(new ImageFileInfo { FileName = ResolveUrl(strFileName.Replace(Server.MapPath("/"), "~/")) });
            }
            grdImages.DataSource = imageFileList;
            grdImages.DataBind();
        }
