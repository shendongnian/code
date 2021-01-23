        public ActionResult Thumbnail()
        {
            string imageFile = System.Web.HttpContext.Current.Server.MapPath("~/Content/tempimg/sti1.jpg");
            var srcImage = Image.FromFile(imageFile);
            var stream = new MemoryStream();
            srcImage.Save(stream , ImageFormat.Png);
            return File(streak.ToArray(), "image/png");
        }
