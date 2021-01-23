        public string ImageDirectory { get { return Server.MapPath(@"~\images\"); } }
        public void OnUploadClick(object sender, EventArgs e)
        {
            var files = HttpContext.Request.Files.AllKeys.AsEnumerable()
				.Select(k =>HttpContext.Request.Files[k]);
            foreach(var file in files)
            {
                if(file.ContentLength <= 0)
                    continue;
                string savePath = GetFullSavePath(file);
                var dimensions = new Size(100, 100);
                CreateThumbnail(file,savePath,dimensions);
            }
        }
        private void CreateThumbnail(HttpPostedFile file,string savePath, Size dimensions)
        {
            using (var image = Image.FromStream(file.InputStream))
            {
                using (var thumb = image.GetThumbnailImage(dimensions.Width, dimensions.Height, () => false, IntPtr.Zero))
                {
                    thumb.Save(savePath);
                }
            }
        }
        private string GetFullSavePath(HttpPostedFile file)
        {
            string fileName = System.IO.Path.GetFileName(file.FileName).Replace(" ", "");
            string savePath = System.IO.Path.Combine(this.ImageDirectory, fileName);
            return savePath;
        }
