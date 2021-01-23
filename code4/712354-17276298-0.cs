    public string DriveOnRight
    {
        get { return (string)GetValue(DriveOnRightProperty); }
        set { SetValue(DriveOnRightProperty, value); }
    }
    public static readonly DependencyProperty DriveOnRightProperty =
        DependencyProperty.Register("DriveOnRight", typeof(string), typeof(GalleryDictionary));
