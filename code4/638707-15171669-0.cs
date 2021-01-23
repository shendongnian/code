    using (var stream = await contact.GetThumbnailAsync())
    {
        BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);
        BitmapFrame frame = await decoder.GetFrameAsync(0);
        var bitmap = new WriteableBitmap((int)frame.PixelWidth, (int)frame.PixelHeight);
        stream.Seek(0);
        await bitmap.SetSourceAsync(stream);
    }
