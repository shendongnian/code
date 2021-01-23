     protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Test/") + "test.jpg");
                string pth = Server.MapPath("~/Test/test.jpg");
                resizeImageAndSave(pth);
            }
        }
        private string resizeImageAndSave(string imagePath)
        {
           
            System.Drawing.Image fullSizeImg
                 = System.Drawing.Image.FromFile(imagePath);
            var thumbnailImg = new Bitmap(150, 130);
            var thumbGraph = Graphics.FromImage(thumbnailImg);
            thumbGraph.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            thumbGraph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            thumbGraph.InterpolationMode =System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            var imageRectangle = new Rectangle(0, 0, 150, 130);
            thumbGraph.DrawImage(fullSizeImg, imageRectangle);
            string targetPath = imagePath.Replace(Path.GetFileNameWithoutExtension(imagePath), Path.GetFileNameWithoutExtension(imagePath) + "-resize");
            thumbnailImg.Save(targetPath, System.Drawing.Imaging.ImageFormat.Jpeg); //(A generic error occurred in GDI+) Error occur here !
            thumbnailImg.Dispose();
            return targetPath;
        }
