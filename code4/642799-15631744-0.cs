    StorageFile originalImageFile;
    WriteableBitmap cropBmp;
    public async Task<WriteableBitmap> GetWB()
    {
        if (originalImageFile != null)
        {
            //originalImageFile is the image either loaded from file or captured image.
            using (IRandomAccessStream stream = await originalImageFile.OpenReadAsync())
            {
                BitmapImage bmp = new BitmapImage();
                bmp.SetSource(stream);
                BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);
                byte[] pixels = await GetPixelData(decoder, Convert.ToUInt32(bmp.PixelWidth), Convert.ToUInt32(bmp.PixelHeight));
                cropBmp = new WriteableBitmap(bmp.PixelWidth, bmp.PixelHeight);
                Stream pixStream = cropBmp.PixelBuffer.AsStream();
                pixStream.Write(pixels, 0, (int)(bmp.PixelWidth * bmp.PixelHeight * 4));
            } 
        }
        return cropBmp;
    }
