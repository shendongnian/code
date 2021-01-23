      private static void VaryQualityLevel(Image imgToResize,string imageName)
          {
            // Get a bitmap.
            Bitmap bmp1 = new Bitmap(imgToResize);
            ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);
            // Create an Encoder object based on the GUID
            // for the Quality parameter category.
            System.Drawing.Imaging.Encoder myEncoder =
                System.Drawing.Imaging.Encoder.Quality;
            // Create an EncoderParameters object.
            // An EncoderParameters object has an array of EncoderParameter
            // objects. In this case, there is only one
            // EncoderParameter object in the array.
            EncoderParameters myEncoderParameters = new EncoderParameters(1);
            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder,
                50L);
            myEncoderParameters.Param[0] = myEncoderParameter;
             
            var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Download/"), imageName+".jpeg");
            bmp1.Save(fileSavePath, jgpEncoder,
                myEncoderParameters);
            //myEncoderParameter = new EncoderParameter(myEncoder, 100L);
            //myEncoderParameters.Param[0] = myEncoderParameter;
            //fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Download/"), "TestPhotoQuality100.jpeg");
            //bmp1.Save(fileSavePath, jgpEncoder,
            //    myEncoderParameters);
            // Save the bitmap as a JPG file with 75 quality level compression.
            myEncoderParameter = new EncoderParameter(myEncoder, 75L);
            //myEncoderParameters.Param[0] = myEncoderParameter;
            //fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Download/"), "TestPhotoQuality75.jpeg");
            //bmp1.Save(fileSavePath, jgpEncoder,
            //    myEncoderParameters);
        }
        private static ImageCodecInfo GetEncoder(ImageFormat format)
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
