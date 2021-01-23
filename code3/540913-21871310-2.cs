        /// <summary>
        /// Convert Tiff image to another mime-type bitmap
        /// </summary>
        /// <param name="tiffImage">Source TIFF file</param>
        /// <param name="mimeType">Desired result mime-type</param>
        /// <returns>Converted image</returns>
        public Bitmap ConvertTiffToBitmap(Image tiffImage, string mimeType)
        {
            var imageCodecInfo = ImageCodecInfo.GetImageEncoders().FirstOrDefault(encoder => encoder.MimeType == "image/tiff");
            if (imageCodecInfo == null)
            {
                return null;
            }
            Bitmap sourceImg;
            using (var memoryStream = new MemoryStream())
            {
                // Setting encode params
                var imageEncoderParams = new EncoderParameters(1);
                imageEncoderParams.Param[0] = new EncoderParameter(Encoder.Quality, 100L);
                tiffImage.Save(memoryStream, imageCodecInfo, imageEncoderParams);
                tiffImage.Dispose();
                var ic = new ImageConverter();
                // Reading stream data to new image
                var tempTiffImage = (Image)ic.ConvertFrom(memoryStream.GetBuffer());
                // Setting new result mime-type
                imageCodecInfo = ImageCodecInfo.GetImageEncoders().FirstOrDefault(encoder => encoder.MimeType == mimeType);
                if (tempTiffImage != null) tempTiffImage.Save(memoryStream, imageCodecInfo, imageEncoderParams);
                sourceImg = new Bitmap(Image.FromStream(memoryStream, true));
    
            }
            return sourceImg;
        }
