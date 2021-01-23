    private static string resizeImageAndSave(string imagePath)
    {
        System.Drawing.Image fullSizeImg = System.Drawing.Image.FromFile(Server.MapPath(imagePath));
        var thumbnailImg = new Bitmap(565, 290);
        var thumbGraph = Graphics.FromImage(thumbnailImg);
        thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
        thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
        thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
        var imageRectangle = new Rectangle(0, 0, 565, 290);
        thumbGraph.DrawImage(fullSizeImg, imageRectangle);
        fullSizeImg.Dispose(); //Dispose of the original image
        string targetPath = imagePath.Replace(Path.GetFileNameWithoutExtension(imagePath), Path.GetFileNameWithoutExtension(imagePath) + "-resize");
        Bitmap temp = thumbnailImg.Clone() as Bitmap; //Cloning
        thumbnailImg.Dispose();
        temp.Save(targetPath, ImageFormat.Jpeg); 
        temp.Dispose();
        return targetPath;
    }
