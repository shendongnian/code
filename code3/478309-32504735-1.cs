           public static class BitmapExtension
           {
              public static void Save(this Bitmap bitmap, String fileName, ImageFormat imageFormat, long quality = 75L)
              {
                 using (var encoderParameters = new EncoderParameters(1))
                 using (encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality))
                 {
                    ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
        
                    bitmap.Save(fileName, codecs.Single(codec => codec.FormatID == imageFormat.Guid), encoderParameters);
                 }
              }
           }
    
           ...
    
           Bitmap bitmap = new Bitmap("myImage.bmp");
    
           bitmap.Save("myImage.jpg", ImageFormat.Jpeg, 50L);
