            if (IsPostBack && Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                var bmp = new Bitmap(file.InputStream);
                var croppedBmp = ImageHelper.CropUnwantedBackground(bmp);
                Response.ContentType = file.ContentType;
                croppedBmp.Save(Response.OutputStream, ImageFormat.Jpeg);
                Response.End();
            }
