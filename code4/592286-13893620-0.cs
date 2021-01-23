    public static System.Drawing.Image CropBitmap(Bitmap bitmap, int cropX, int cropY, int cropWidth, int cropHeight)
            {
                System.Drawing.Rectangle rect = new System.Drawing.Rectangle(cropX, cropY, cropWidth, cropHeight);
                System.Drawing.Image cropped = bitmap.Clone(rect, bitmap.PixelFormat);
                return cropped;
            }
