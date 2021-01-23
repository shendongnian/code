       public static class BitmapExtension
       {
          public static Stream GetStream(this Bitmap bitmap, long quality, ImageFormat imageFormat)
          {
             Stream stream = new MemoryStream();
             using (var encoderParameters = new EncoderParameters(1))
             using(encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, quality))
             {
                ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
    
                bitmap.Save(stream, codecs.Single(codec => codec.FormatID == imageFormat.Guid), encoderParameters);
             }
    
             stream.Position = 0;
    
             return stream;
          }
    
       }
