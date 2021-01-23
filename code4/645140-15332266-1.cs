    public Byte[] ImageBytes
    {
        get { return _imageBytes; }
        set
        {
            if (Equals(value, _imageBytes)) return;
            _imageBytes = value;
            OnPropertyChanged();
            CreateBitmap();
        }
    }
    public BitmapSource Image
    {
        get { return _image; }
        set
        {
            if (Equals(value, _image)) return;
            _image = value;
            OnPropertyChanged();
        }
    }
    private async Task CreateBitmap()
    {
        try
        {
            BitmapImage bitmapImage = new BitmapImage();
            IRandomAccessStream stream = await this.ConvertToRandomAccessStream(ImageBytes);
            bitmapImage.SetSource(stream);
            Image = bitmapImage;
        }
        catch
        {
            Image = null;
        }
    }
