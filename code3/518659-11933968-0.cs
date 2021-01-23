    // First, we convert an HttpPostedFileBase to an Image
    // (Please note that you need to reference System.Drawing.dll)
    using (var image = Image.FromStream(httpPostedFileBase.InputStream, true, true))
    {
        // Then we create a thumbnail.
        // The simplest way is using Image.GetThumbnailImage:
        using (var thumb = image.GetThumbnailImage(
            thumbWidth,
            thumbHeight,
            () => false,
            IntPtr.Zero))
        {
            // Finally, we encode and save the thumbnail.
            var jpgInfo = ImageCodecInfo.GetImageEncoders()
                .Where(codecInfo => codecInfo.MimeType == "image/jpeg").First();
            
            using (var encParams = new EncoderParameters(1))
            {
                // Your output path
                string outputPath = "...";
                // Image quality (should be in the range [0..100])
                long quality = 90;
                encParams.Param[0] = new EncoderParameter(Encoder.Quality, quality);
                thumb.Save(outputPath, jpgInfo, encParams);
            }
        }
    }
