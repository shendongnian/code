    protected void YourUploadButton_Click(object sender, EventArgs e)
    {
            //Get files to be deleted
            string[] filesToDelete = this.filesToDelete.Value.Split(',');
            //Your collection of files
            HttpFileCollection uploadFiles = Request.Files;
            for (int i = 0; i < uploadFiles.Count; i++)
            {
                //Checks the Posted File
                HttpPostedFile postedFile = uploadFiles[i];
                //If it isn't a file meant for deletion - don't upload
                if (!filesToDelete.Any(c => c == postedFile.FileName))
                {
                    UploadToFTP(postedFile, i);
                }
 
            }
    }
