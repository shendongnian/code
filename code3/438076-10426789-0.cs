 public void ProcessRequest(HttpContext context)
        {
            var imagePath = QueryString.getValueOf("ID");
            var watermark = QueryString.getValueOf("watermark");
            string lstrResponseType;
            //  context.Response.ContentType = "image/jpeg";
            if (string.IsNullOrWhiteSpace(imagePath) || string.IsNullOrWhiteSpace(watermark))
            {
                using (var originalImage = Image.FromFile(context.Server.MapPath("Images/NoImage.jpg")))
                {
                    originalImage.Save(context.Response.OutputStream, ImageFormat.Jpeg);
                    originalImage.Dispose();
                }
                lstrResponseType = "image/jpeg";
            }
            else
            {
                var absolutePath = context.Server.MapPath(imagePath);
                var fileexist = System.IO.File.Exists(absolutePath);
                if (!fileexist)
                {
                    var originalImage = Image.FromFile(context.Server.MapPath("Images/NoImage.jpg"));
                    originalImage.Save(context.Response.OutputStream, ImageFormat.Jpeg);
                    lstrResponseType = "image/jpeg";
                    originalImage.Dispose();
                }
                else
                {
                    using (var originalImage = Image.FromFile(absolutePath))
                    {
                        if (watermark == "0")
                        {
                            originalImage.Save(context.Response.OutputStream, ImageFormat.Jpeg);
                            lstrResponseType = "image/jpeg";
                        }
                        else
                        {
                            if (imagePath.ToUpper().Contains(".GIF"))
                            {
                                originalImage.Save(context.Response.OutputStream, ImageFormat.Gif);
                                lstrResponseType = "image/gif";
                            }
                            else
                            {
                                new ImageMethods().AddWatermarkText(originalImage);
                                originalImage.Save(context.Response.OutputStream, ImageFormat.Jpeg);
                                lstrResponseType = "image/jpeg";
                            }
                        }
                    }
                }
            }
            context.Response.ContentType = lstrResponseType;
        }
