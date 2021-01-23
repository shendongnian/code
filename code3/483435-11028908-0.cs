    public ActionResult UploadImage(HttpPostedFileBase imageFile, int id)
    {
        if (imageFile == null || imageFile.ContentLength == 0)
        {
            return new WrappedJsonResult
            {
                Data = new
                {
                    IsValid = false,
                    Message = "No file was uploaded.",
                    ImagePath = string.Empty
                }
            };
        }
        var fileName = String.Format("{0}_{1}.jpg", id, Guid.NewGuid().ToString());
        var imagePath = Path.Combine(Server.MapPath(Url.Content("~/Content/UploadPhoto")), fileName);
        using (var input = new Bitmap(imageFile.InputStream))
        {
            int width;
            int height;
            if (input.Width > input.Height)
            {
                width = 411;
                height = 411 * input.Height / input.Width;
            }
            else
            {
                height = 411;
                width = 411 * input.Width / input.Height;
            }
            using (var thumb = new Bitmap(width, height))
            using (var graphic = Graphics.FromImage(thumb))
            {
                graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphic.SmoothingMode = SmoothingMode.AntiAlias;
                graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphic.DrawImage(input, 0, 0, width, height);
                using (var output = System.IO.File.Create(imagePath))
                {
                    thumb.Save(output, ImageFormat.Jpeg);
                }
            }
        }
        ...
    }
