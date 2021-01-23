    using (ZipFile zipFile = new ZipFile())
    {
        foreach (var userPicture in userPictures)
        {
            string pictureName = userPicture.Name + ".png";
            using (MemoryStream tempstream = new MemoryStream())
            {
                Image userImage = //method that returns Drawing.Image from byte[];   
                userImage.Save(tempstream, ImageFormat.Png);  
                tempstream.Seek(0, SeekOrigin.Begin);
                byte[] imageData = new byte[tempstream.Length];
                tempstream.Read(imageData, 0, imageData.Length);
                zipFile.AddEntry(pictureName, imageData);
            }
        }
        zipFile.Save(Response.OutputStream);
    }
