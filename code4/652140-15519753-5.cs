     string[] validTypes = { "bmp", "gif"};
     string ext = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
     int pos = Array.IndexOf(validTypes , ext );
     if(pos>=0)
     {
         string path = @"~\Images\"; 
         string comPath = Server.MapPath(path + "\\" + FileUpload1.FileName);
         if (!File.Exists(comPath))
         {
             FileUpload1.PostedFile.SaveAs(comPath);
             Label1.Text = "File uploaded";
         }
         else
         {
             Label1.Text = "Existed";
         }
     }
     else
     {
        Label1.Text = "Invalid File." + string.Join(",", validTypes);
     }
