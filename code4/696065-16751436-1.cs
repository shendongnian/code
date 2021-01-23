      //get the file name of the posted image
        string imgName = image.FileName.ToString();
        String path = Server.MapPath("~/ImageStorage");//Path
        //Check if directory exist
        if (!System.IO.Directory.Exists(path))
        {
            System.IO.Directory.CreateDirectory(path); //Create directory if it doesn't exist
        }
        //sets the image path
        string imgPath = Path.Combine(path, imgName);
        //get the size in bytes that
        int imgSize = image.PostedFile.ContentLength;
        if (image.PostedFile != null)
        {
            if (image.PostedFile.ContentLength > 0)//Check if image is greater than 5MB
            {
                //Save image to the Folder
                image.SaveAs(imgPath);
            }
        }
