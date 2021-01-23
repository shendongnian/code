    private static byte[] ResizeAlbumArt(byte[] originalAlbumArtData)
    {
        using (var originalStream = new MemoryStream(originalAlbumArtData))
        {
            var original = new Bitmap(originalStream);
            var target = new Bitmap(AlbumArtDimensions, AlbumArtDimensions);
            using (var g = Graphics.FromImage(target))
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.DrawImage(original, 0, 0, target.Width, target.Height);
            }
            using (var outputStream = new MemoryStream())
            {
                target.Save(outputStream, ImageFormat.Bmp);
                return outputStream.ToArray();
            }
        }
    }
