    private string resizeImageAndSave(string imagePath)
        {
            System.Drawing.Image fullSizeImg
                 = System.Drawing.Image.FromFile(imagePath);
            var thumbnailImg = new Bitmap(565, 290);
            var thumbGraph = Graphics.FromImage(thumbnailImg);
            thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
            thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
            thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            var imageRectangle = new Rectangle(0, 0, 565, 290);
            thumbGraph.DrawImage(fullSizeImg, imageRectangle);
            string targetPath = imagePath.Replace(Path.GetFileNameWithoutExtension(imagePath), Path.GetFileNameWithoutExtension(imagePath) + "-resize");
            thumbnailImg.Save(targetPath, ImageFormat.Jpeg); //(A generic error occurred in GDI+) Error occur here !
            thumbnailImg.Dispose();
            return targetPath;
        }
        protected void bntUploadFile_Click(object sender, EventArgs e)
        {
            string file = Server.MapPath("tree.jpg");
            resizeImageAndSave(file);
        }
