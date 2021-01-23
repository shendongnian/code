    public static bool ImageCompareString(Image firstImage, Image secondImage)
        {
            var ms = new MemoryStream(); firstImage.Save(ms, ImageFormat.Png); String firstBitmap
                = Convert.ToBase64String(ms.ToArray()); ms.Position = 0; secondImage.Save(ms, ImageFormat.Png);
            String secondBitmap = Convert.ToBase64String(ms.ToArray()); if (firstBitmap.Equals(secondBitmap))
            { return true; }
            else { return false; }
        }
