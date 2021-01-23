    protected async override void OnNavigatedTo(NavigationEventArgs e)
    {
        StorageFile destiFile = await ApplicationData.Current.TemporaryFolder.CreateFileAsync("Merged.png", CreationCollisionOption.ReplaceExisting);
    
        WriteableBitmap wb;
    
        wb = await Render();
    
        using (IRandomAccessStream stream = await destiFile.OpenAsync(FileAccessMode.ReadWrite))
        {
            BitmapEncoder encoder = await BitmapEncoder.CreateAsync(
                BitmapEncoder.PngEncoderId, stream);
            Stream pixelStream = wb.PixelBuffer.AsStream();
            byte[] pixels = new byte[pixelStream.Length];
            await pixelStream.ReadAsync(pixels, 0, pixels.Length);
    
            encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore,
                (uint)wb.PixelWidth, (uint)wb.PixelHeight, 96.0, 96.0, pixels);
            await encoder.FlushAsync();
        }
    
        var bitmp = new BitmapImage();
        using (var strm = await destiFile.OpenReadAsync())
        {
            bitmp.SetSource(strm);
            imgTarget.Source = bitmp;
        }
    }
    
    private async Task<WriteableBitmap> Render()
    {
        var Assets = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
       
        StorageFile file1 = await Assets.GetFileAsync("img1.png");
        StorageFile file2 = await Assets.GetFileAsync("img2.png");
    
        BitmapImage i1 = new BitmapImage();
        BitmapImage i2 = new BitmapImage();
        
        using (IRandomAccessStream strm = await file1.OpenReadAsync())
        {
            i1.SetSource(strm);
        }
    
        using (IRandomAccessStream strm = await file2.OpenReadAsync())
        {
            i2.SetSource(strm);
        }
    
        WriteableBitmap img1 = new WriteableBitmap(i1.PixelWidth, i1.PixelHeight);
        WriteableBitmap img2 = new WriteableBitmap(i2.PixelWidth, i2.PixelHeight);
        using (IRandomAccessStream strm = await file1.OpenReadAsync())
        {
            img1.SetSource(strm);
        }
    
        using (IRandomAccessStream strm = await file2.OpenReadAsync())
        {
            img2.SetSource(strm);
        }
    
       
        WriteableBitmap destination = new WriteableBitmap((int)(img1.PixelWidth > img2.PixelWidth ? img1.PixelWidth : img2.PixelWidth), (int)(img1.PixelHeight + img1.PixelHeight));
        destination.Clear(Colors.White);
        destination.Blit(new Rect(0, 0, (int)img1.PixelWidth, (int)img1.PixelHeight),img1,new Rect(0, 0, (int)img1.PixelWidth, (int)img1.PixelHeight));
        destination.Blit(new Rect(0, (int)img1.PixelHeight, (int)img2.PixelWidth, (int)img2.PixelHeight), img2, new Rect(0, 0, (int)img2.PixelWidth, (int)img2.PixelHeight));
        return destination;
    }
