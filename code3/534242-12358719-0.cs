    internal static async Task LoadTileImageInternalAsync(string imagePath)
    {
        string tileName = imagePath.GetHashedTileName();
        StorageFile origFile = await ApplicationData.Current.LocalFolder.GetFileAsync(imagePath);
        // open file for the new tile image file
        StorageFile tileFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(tileName, CreationCollisionOption.ReplaceExisting);
        using (IRandomAccessStream tileStream = await tileFile.OpenAsync(FileAccessMode.ReadWrite))
        {
            // get width and height from the original image
            IRandomAccessStreamWithContentType stream = await origFile.OpenReadAsync();
            ImageProperties properties = await origFile.Properties.GetImagePropertiesAsync();
            uint width = properties.Width;
            uint height = properties.Height;
            // get proper decoder for the input file - jpg/png/gif
            BitmapDecoder decoder = await GetProperDecoder(stream, imagePath);
            if (decoder == null) return; // should not happen
            // get byte array of actual decoded image
            PixelDataProvider data = await decoder.GetPixelDataAsync();
            byte[] bytes = data.DetachPixelData();
            // create encoder for saving the tile image
            BitmapPropertySet propertySet = new BitmapPropertySet();
            // create class representing target jpeg quality - a bit obscure, but it works
            BitmapTypedValue qualityValue = new BitmapTypedValue(TargetJpegQuality, PropertyType.Single);
            propertySet.Add("ImageQuality", qualityValue);
            // create the target jpeg decoder
            BitmapEncoder be = await BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, tileStream, propertySet);
            be.SetPixelData(BitmapPixelFormat.Rgba8, BitmapAlphaMode.Straight, width, height, 96.0, 96.0, bytes);
            // crop the image, if it's too big
            if (width > MaxImageWidth || height > MaxImageHeight)
            {
                BitmapBounds bounds = new BitmapBounds();
                if (width > MaxImageWidth)
                {
                    bounds.Width = MaxImageWidth;
                    bounds.X = (width - MaxImageWidth) / 2;
                }
                if (height > MaxImageHeight)
                {
                    bounds.Height = MaxImageHeight;
                    bounds.Y = (height - MaxImageHeight) / 2;
                }
                be.BitmapTransform.Bounds = bounds;
            }
            // save the target jpg to the file
            await be.FlushAsync();
        }
    }
    private static async Task<BitmapDecoder> GetProperDecoder(IRandomAccessStreamWithContentType stream, string imagePath)
    {
        string ext = Path.GetExtension(imagePath);
        switch (ext)
        {
            case ".jpg":
            case ".jpeg":
                return await BitmapDecoder.CreateAsync(BitmapDecoder.JpegDecoderId, stream);
            case ".png":
                return await BitmapDecoder.CreateAsync(BitmapDecoder.PngDecoderId, stream);
            case ".gif":
                return await BitmapDecoder.CreateAsync(BitmapDecoder.GifDecoderId, stream);
        }
        return null;
    }
