    public class ImageManipulation
    {
        public static Bitmap ResizeImage(Bitmap originalBitmap, int newWidth, int maxHeight, bool onlyResizeIfWider)
        {
            if (onlyResizeIfWider)
            {
                if (originalBitmap.Width <= newWidth)
                {
                    newWidth = originalBitmap.Width;
                }
            }
            int newHeight = originalBitmap.Height * newWidth / originalBitmap.Width;
            if (newHeight > maxHeight)
            {
                // Resize with height instead
                newWidth = originalBitmap.Width * maxHeight / originalBitmap.Height;
                newHeight = maxHeight;
            }
            var alteredImage = new Bitmap(originalBitmap, new Size(newWidth, newHeight));
            alteredImage.SetResolution(72, 72);
            return alteredImage;
        }
    }
