    public class Thumbnail
    {
        private string _filePath;
        private int _maxWidth = 120;
        private int _maxHeight = 120;
        
        public string MimeType;
        public System.Drawing.Imaging.ImageFormat ImageFormat;
        public byte[] ImageBytes;
        public Thumbnail(string filePath, int maxWidth, int maxHeight)
        {
            _filePath = filePath;
            _maxWidth = maxWidth;
            _maxHeight = maxHeight;
            MakeThumbnail();
        }
        private void MakeThumbnail()
        {
            using (Image img = new Bitmap(_filePath))
            {
                Size newSize = GenerateImageDimensions(img.Width, img.Height, _maxWidth, _maxHeight);
                int imgWidth = newSize.Width;
                int imgHeight = newSize.Height;
                // create the thumbnail image
                using (Image img2 =
                          img.GetThumbnailImage(imgWidth, imgHeight,
                          new Image.GetThumbnailImageAbort(Abort),
                          IntPtr.Zero))
                {
                    using (Graphics g = Graphics.FromImage(img2)) // Create Graphics object from original Image
                    {
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                        g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                        //BMP 0, JPEG 1 , GIF 2 , TIFF 3, PNG 4
                        System.Drawing.Imaging.ImageCodecInfo codec;
                        switch (Path.GetExtension(_filePath))
                        {
                            case ".gif":
                                codec = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders()[2];
                                ImageFormat = System.Drawing.Imaging.ImageFormat.Gif;
                                MimeType = "image/gif";
                                break;
                            case ".png":
                                codec = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders()[4];
                                ImageFormat = System.Drawing.Imaging.ImageFormat.Png;
                                MimeType = "image/png";
                                break;
                            default: //jpg
                                codec = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders()[1];
                                ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
                                MimeType = "image/jpg";
                                break;
                        }
                        //Set the parameters for defining the quality of the thumbnail... here it is set to 100%
                        System.Drawing.Imaging.EncoderParameters eParams = new System.Drawing.Imaging.EncoderParameters(1);
                        eParams.Param[0] = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 90L);
                        //Now draw the image on the instance of thumbnail Bitmap object
                        g.DrawImage(img, new Rectangle(0, 0, img2.Width, img2.Height));
                        MemoryStream ms = new MemoryStream();
                        img2.Save(ms, codec, eParams);
                        ImageBytes = new byte[ms.Length];
                        ImageBytes = ms.ToArray();
                        ms.Close();
                        ms.Dispose();
                    }
                }
            }
        }
        public static Size GenerateImageDimensions(int currW, int currH, int destW, int destH)
        {
            int imgWidth = currW;
            int imgHeight = currH;
            if (imgWidth > destW)
            {
                double rate = (double)imgWidth / (double)destW;
                imgWidth = destW;
                imgHeight = (int)(imgHeight / rate);
            }
            if (imgHeight > destH)
            {
                double rate = (double)imgHeight / (double)destH;
                imgHeight = destH;
                imgWidth = (int)(imgWidth / rate);
            }
            return new Size(imgWidth, imgHeight);
        }
        private bool Abort()
        {
            return false;
        }
    }
