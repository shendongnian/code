    using (System.Drawing.Image myImage = System.Drawing.Image.FromStream(FileUploadJcrop.PostedFile.InputStream))
    {
        if (myImage.Width > 500)
        {
            Double d = (myImage.Height * 500) / myImage.Width;
            Int32 myH = (Int32)Math.Round(d, 0);
            Bitmap src = Bitmap.FromStream(FileUploadJcrop.PostedFile.InputStream) as Bitmap;
            Bitmap result = new Bitmap(500, myH);
            using (Graphics myg = Graphics.FromImage((System.Drawing.Image)result))
            {
                myg.DrawImage(src, 0, 0, 500, myH);
            }
            result.Save(savePath);
            FileSaved = true;
        }
    }
