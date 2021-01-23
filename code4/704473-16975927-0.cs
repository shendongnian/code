    private void UploadFile()
    {
        DatabaseData.DataClassesDataContext context = new DatabaseData.DataClassesDataContext();
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Title = "Select file";
            
            if (dlgOpen.ShowDialog() ?? false)
            {
                FileStream inStream = File.OpenRead(dlgOpen.FileName);
            
                FileData fd = new FileData();
                fd.FileId = Guid.NewGuid();
                fd.DataFile = inStream;
                fd.Title = dlgOpen.FileName;
                fd.FileExtension = txtExtension.text;
        
                context.FileDatas.InsertOnSubmit(fd);
                context.SubmitChanges();
                
                inStream.Close();
            }
        }
    }
