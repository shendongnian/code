    private static readonly ImageSource errorImage =
        Imaging.CreateBitmapSourceFromHIcon(SystemIcons.Error.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
    public static ImageSource ErrorImage
    {
        get { return errorImage; }
    }
