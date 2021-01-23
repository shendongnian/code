    public class ImageHandler
    {
        private Image cropImage(Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            if (bmpImage.Size.Width < cropArea.Width)
                cropArea.Width = bmpImage.Size.Width;
            if (bmpImage.Size.Height < cropArea.Height)
                cropArea.Height = bmpImage.Size.Height;
            Bitmap bmpCrop = bmpImage.Clone(cropArea,
                                            bmpImage.PixelFormat);
            return (Image)(bmpCrop);
        }
        private Image resizeImage(Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;
            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);
            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;
            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);
            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            return (Image)b;
        }
        public Image ResizeWithCrop(Image imgToResize, Size size, bool center = true)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;
            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);
            if (nPercentH < nPercentW)
                nPercent = nPercentW;
            else
                nPercent = nPercentH;
            float resultWidth = sourceWidth * nPercent;
            float resultHeight = sourceHeight * nPercent;
            int destWidth = (int)resultWidth;
            int destHeight = (int)resultHeight;
            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            int restWidth = destWidth - size.Width;
            int restHeight = destHeight - size.Height;
            int pX = center ? restWidth > 0 ? (int)(restWidth / 2) : 0 : 0;
            int pY = center ? restHeight > 0 ? (int)(restHeight / 2) : 0 : 0;
            return cropImage((Image)b, new Rectangle(pX, pY, size.Width, size.Height));
        }
        public void SaveJpeg(string path, Image img, long quality = 85L)
        {
            try
            {
            
            EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            ImageCodecInfo jpegCodec = getEncoderInfo(@"image/jpeg");
            EncoderParameters encoderParams
            = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;
            System.IO.MemoryStream mss = new System.IO.MemoryStream();
            System.IO.FileStream fs
            = new System.IO.FileStream(path, System.IO.FileMode.Create
            , System.IO.FileAccess.ReadWrite);
            img.Save(mss, jpegCodec, encoderParams);
            byte[] matriz = mss.ToArray();
            fs.Write(matriz, 0, matriz.Length);
            mss.Close();
            fs.Close();
            }
            catch (Exception ex)
            {
                
            }
        }
        private ImageCodecInfo getEncoderInfo(string mimeType)
        {
            // Get image codecs for all image formats
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            // Find the correct image codec
            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];
            return null;
        }
        public void SavePng(string path, Image img, long quality = 85L)
        {
            try
            {
                EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
                ImageCodecInfo jpegCodec = getEncoderInfo(@"image/png");
                EncoderParameters encoderParams
                = new EncoderParameters(1);
                encoderParams.Param[0] = qualityParam;
                System.IO.MemoryStream mss = new System.IO.MemoryStream();
                System.IO.FileStream fs
                = new System.IO.FileStream(path, System.IO.FileMode.Create
                , System.IO.FileAccess.ReadWrite);
                img.Save(mss, jpegCodec, encoderParams);
                byte[] matriz = mss.ToArray();
                fs.Write(matriz, 0, matriz.Length);
                mss.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
            }
        }
    }
