    System.Drawing.Image imageToBeResized = System.Drawing.Image.FromStream(fuImage.PostedFile.InputStream);
            int imageHeight = imageToBeResized.Height;
            int imageWidth = imageToBeResized.Width;
            int maxHeight = 240;
            int maxWidth = 320;
            imageHeight = (imageHeight * maxWidth) / imageWidth;
            imageWidth = maxWidth;
            if (imageHeight > maxHeight)
            {
                imageWidth = (imageWidth * maxHeight) / imageHeight;
                imageHeight = maxHeight;
            }
            Bitmap bitmap = new Bitmap(imageToBeResized, imageWidth, imageHeight);
            System.IO.MemoryStream stream = new MemoryStream();
            bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            stream.Position = 0;
            byte[] image = new byte[stream.Length + 1];
            stream.Read(image, 0, image.Length);
            System.IO.FileStream fs
    = new System.IO.FileStream(Server.MapPath("~/image/a.jpg"), System.IO.FileMode.Create
    , System.IO.FileAccess.ReadWrite);
                fs.Write(image, 0, image.Length);
