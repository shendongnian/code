     public static void CopyPixelsTo(this BitmapSource sourceImage, Int32Rect sourceRoi, WriteableBitmap destinationImage, Int32Rect destinationRoi)
        {
            var croppedBitmap = new CroppedBitmap(sourceImage, sourceRoi);
            int stride = croppedBitmap.PixelWidth * (croppedBitmap.Format.BitsPerPixel / 8);
            var data = new byte[stride * croppedBitmap.PixelHeight];
            // Is it possible to Copy directly from the sourceImage into the destinationImage?
            croppedBitmap.CopyPixels(data, stride, 0);
            destinationImage.WritePixels(destinationRoi,data,stride,0);
        }
