    protected void Button1_Click(object sender, EventArgs e)
            {
                var cloudIdentity = new CloudIdentity() { Username = "Rackspace_user_name", APIKey = "Rackspace_api" };
                var cloudFilesProvider = new CloudFilesProvider(cloudIdentity);
    
    
                byte[] buffer = new byte[FileUpload1.FileBytes.Length];
                FileUpload1.FileContent.Seek(0, SeekOrigin.Begin);
                FileUpload1.FileContent.Read(buffer, 0, Convert.ToInt32(FileUpload1.FileContent.Length));
                Stream stream2 = new MemoryStream(buffer);
                try
                {
                    using (FileUpload1.PostedFile.InputStream)
                    {
                        cloudFilesProvider.CreateObject("Containers_name", stream2, FileUpload1.FileName); //blockBlob.UploadFromStream(fileASP.PostedFile.InputStream);
                    }
                }
    
                catch (Exception ex)
                {
    
                
    
        Label1.Text = ex.ToString();
    
                }
            }
      
