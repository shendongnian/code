     var countUploads = ChildrenCountTextPanel.Controls.OfType<FileUpload>();
 
            FileUpload FileUl = new FileUpload();
            foreach (var ul in countUploads)
            {
                if(ul.ID.Contains("imgUpload_"))
                {
                    FileUl = ul;               
                }
            }
    if (FileUl.HasFile)
    {
     ConvertAndSave(FileUl)
     }
