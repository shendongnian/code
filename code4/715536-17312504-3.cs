      private void AddDocuments(int jurisdictionID, Dictionary<string,FileUpload> docPathsAndControl)
        {
             foreach (var item in docPathsAndControl)
             {
                 string tempfilename = jurisdictionID + "_" + item.Key.ToString();
                 string path = Server.MapPath("Dir\\" + tempfilename);
                 FileUpload FileUploaderControl = (FileUpload)item.Value;
                 FileUploaderControl.PostedFile.SaveAs(path);
    
              }
        }
