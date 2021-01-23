    public static DependencyProperty VideoDirectoryProperty = DependencyProperty.Register("VideoDirectory", typeof(string), typeof(WebCam), 
         new FrameworkPropertyMetadata(new PropertyChangedCallback(DirectoryChange)));
    private static void DirectoryChange(DependencyObject source, DependencyPropertyChangedEventArgs e )
    {
    }
