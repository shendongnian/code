        System.Drawing.Image userImage = new Bitmap(ImagePath);
        
        System.IO.MemoryStream imageMemoryStream = new MemoryStream();
        userImage.Save(imageMemoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
        byte[] ImageByteArray = imageMemoryStream.ToArray();
