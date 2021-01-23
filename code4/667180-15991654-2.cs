    void buttonUpload_Click(object sender, EventArgs e)
    {
        List<string> generatedFileNames = new List<string>();
        bool wereErrors = false;
    
        for (int i = 0; i < Helper.uploadFieldsCount; i++)
        {
            HttpPostedFile filePosted = Request.Files["uploadField" + i.ToString()];
    
            if (filePosted != null && filePosted.ContentLength > 0)
            {
                string fileNameApplication = System.IO.Path.GetFileName(filePosted.FileName);
                string fileExtensionApplication = System.IO.Path.GetExtension(fileNameApplication);
                string newFile = Guid.NewGuid().ToString() + fileExtensionApplication;
                string filePath = System.IO.Path.Combine(Server.MapPath("uploads"), newFile);
    
                if (fileNameApplication != String.Empty)
                {
                    generatedFileNames.Add(newFile);
                    filePosted.SaveAs(filePath);
                }
           }
    ...
