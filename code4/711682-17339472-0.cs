        private string resizeImageAndSave(byte[] imageBytes, string fileName) {
            var mem = new MemoryStream(imageBytes);
            System.Drawing.Image fullSizeImg = System.Drawing.Image.FromStream(mem);
            var thumbnailImg = new Bitmap(565, 290);
            var thumbGraph = Graphics.FromImage(thumbnailImg);
            thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
            thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
            thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            var imageRectangle = new Rectangle(0, 0, 565, 290);
            thumbGraph.DrawImage(fullSizeImg, imageRectangle);
            string targetPath = Path.Combine(Server.MapPath("~/App_Data"), Path.GetFileNameWithoutExtension(fileName) + "-resize.jpg");
            thumbnailImg.Save(targetPath, ImageFormat.Jpeg); //(A generic error occurred in GDI+) Error occur here !
            thumbnailImg.Dispose();
            return targetPath;
        }
        protected void SaveButton_Click(object sender, EventArgs e) {
            var inStream = Request.Files[0].InputStream;
            var buff = new byte[inStream.Length];
            inStream.Read(buff, 0, buff.Length);
            resizeImageAndSave(buff, Request.Files[0].FileName);
        }
