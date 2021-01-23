    using (var memStream = new MemoryStream())
    {
        memStream.Write(fileData, 0, fileData.Length);
        using(Image image = Image.FromStream(memStream))
        {
            using (var graphics = Graphics.FromImage(image))
            {
                graphics.DrawImage(image, model.x1, model.y1, (model.x2 - model.x1), (model.y2 - model.y1));
                graphics.Save();
            }
    
            using (var outStream = new MemoryStream())
            {
                image.Save(outStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                return File(outStream.ToArray(), "image/jpeg");
            }
        }
    }
