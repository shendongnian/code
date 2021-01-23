     [HttpPost]
            [Route("UploadImages")]
            public HttpResponseMessage Post()
            {
                HttpResponseMessage response = new HttpResponseMessage();
                var httpRequest = HttpContext.Current.Request;
                if (httpRequest.Files.Count > 0)
                {
                    var docfiles = new List<string>();
                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];
                        var filePath1 = HttpContext.Current.Server.MapPath("~/ImgFolder/" + postedFile.FileName);
    
                        Stream strm = postedFile.InputStream;
    
                        CreateThumbnail(strm, postedFile.FileName);
    
                        Compressimage(strm, filePath1, postedFile.FileName);
                      
    
                    }
                    response = Request.CreateResponse(HttpStatusCode.Created, docfiles);
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                return response;
            }
            public static void **CreateThumbnail**(Stream sourcePath, string filename)
            {
                Image image = Image.FromStream(sourcePath);
                Image thumb = image.GetThumbnailImage(120, 120, () => false, IntPtr.Zero);
                 var filePath1 = HttpContext.Current.Server.MapPath("~/Thumbnail/" + filename);
    
                 thumb.Save(filePath1 + filename);
               
            }
    
            public static void Compressimage(Stream sourcePath, string targetPath, String filename)  
            {  
      
      
                try  
                {  
                    using (var image = Image.FromStream(sourcePath))  
                    {  
                        float maxHeight = 900.0f;  
                        float maxWidth = 900.0f;  
                        int newWidth;  
                        int newHeight;  
                        string extension;  
                        Bitmap originalBMP = new Bitmap(sourcePath);  
                        int originalWidth = originalBMP.Width;  
                        int originalHeight = originalBMP.Height;  
      
                        if (originalWidth > maxWidth || originalHeight > maxHeight)  
                        {  
      
                            // To preserve the aspect ratio  
                            float ratioX = (float)maxWidth / (float)originalWidth;  
                            float ratioY = (float)maxHeight / (float)originalHeight;  
                            float ratio = Math.Min(ratioX, ratioY);  
                            newWidth = (int)(originalWidth * ratio);  
                            newHeight = (int)(originalHeight * ratio);  
                        }  
                        else  
                        {  
                            newWidth = (int)originalWidth;  
                            newHeight = (int)originalHeight;  
      
                        }  
                        Bitmap bitMAP1 = new Bitmap(originalBMP, newWidth, newHeight);  
                        Graphics imgGraph = Graphics.FromImage(bitMAP1);  
                        extension = Path.GetExtension(targetPath);  
                        if (extension == ".png" || extension == ".gif")  
                        {  
                            imgGraph.SmoothingMode = SmoothingMode.AntiAlias;  
                            imgGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;  
                            imgGraph.DrawImage(originalBMP, 0, 0, newWidth, newHeight);  
    
      
                            bitMAP1.Save(targetPath, image.RawFormat);  
      
                            bitMAP1.Dispose();  
                            imgGraph.Dispose();  
                            originalBMP.Dispose();  
                        }  
                        else if (extension == ".jpg")  
                        {  
      
                            imgGraph.SmoothingMode = SmoothingMode.AntiAlias;  
                            imgGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;  
                            imgGraph.DrawImage(originalBMP, 0, 0, newWidth, newHeight);  
                            ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);  
                            Encoder myEncoder = Encoder.Quality;  
                            EncoderParameters myEncoderParameters = new EncoderParameters(1);  
                            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 50L);  
                            myEncoderParameters.Param[0] = myEncoderParameter;  
                            bitMAP1.Save(targetPath, jpgEncoder, myEncoderParameters);  
      
                            bitMAP1.Dispose();  
                            imgGraph.Dispose();  
                            originalBMP.Dispose();  
      
                        }  
      
                       
                    }  
      
                }  
                catch (Exception)  
                {  
                    throw;  
      
                }  
            }  
      
      
            public static ImageCodecInfo GetEncoder(ImageFormat format)  
            {  
      
                ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();  
      
                foreach (ImageCodecInfo codec in codecs)  
                {  
                    if (codec.FormatID == format.Guid)  
                    {  
                        return codec;  
                    }  
                }  
                return null;  
            }  
      
