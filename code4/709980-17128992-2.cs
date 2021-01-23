    protected void btnUpload_Click(object sender, EventArgs e)
    {
        HttpFileCollection files = Request.Files;
        foreach (string fileTagName in files)
        {
                HttpPostedFile file = Request.Files[fileTagName];
                if (file.ContentLength > 0)
                {
                        int size = file.ContentLength;
                        string name = file.FileName;
                        int position = name.LastIndexOf("\\");
                        name = name.Substring(position + 1);
                        string contentType = file.ContentType;
                        byte[] fileData = new byte[size];
                        file.InputStream.Read(fileData, 0, size);
                        FileUtilities.SaveFile(name, contentType, size, fileData);
                }
        }
        DataTable fileList = FileUtilities.GetFileList();
        gvFiles.DataSource = fileList;
        gvFiles.DataBind();
    }
