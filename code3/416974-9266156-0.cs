        public ActionResult Thumbnail()
        {
            int width = 300;
            int height =200;
            string imageFile = System.Web.HttpContext.Current.Server.MapPath("~/Content/Images/myFileName.jpg");
            using (var srcImage = Image.FromFile(imageFile))
            using (var newImage = new Bitmap(width, height))
            using (var graphics = Graphics.FromImage(newImage))
            using (var stream = new MemoryStream())
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.DrawImage(srcImage, new Rectangle(0, 0, width, height));
                newImage.Save(stream, ImageFormat.Png);
                return File(stream.ToArray(), "image/png");
            }
        }
