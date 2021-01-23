            //save file in folder
        if (FileUpload1.PostedFile.ContentType.ToLower().StartsWith
                ("image") && FileUpload1.HasFile)
        {
            string savelocation = Server.MapPath("savedImages/");
            string fileExtention = System.IO.Path.GetExtension(FileUpload1.FileName);
            //creating filename to avoid file name conflicts.
            string fileName = Guid.NewGuid().ToString();
            //saving file in savedImage folder.
            string savePath = savelocation + fileName + fileExtention;
            FileUpload1.SaveAs(savePath);
        }
