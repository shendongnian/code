     string[] validTypes = { "bmp", "gif"};
     string ext = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
     int pos = Array.IndexOf(validTypes , ext );
     if(pos>=0)
     {
         //file exist code
     }
