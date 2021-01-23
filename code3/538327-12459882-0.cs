    public string FilePath
    {
        get { return (string)GetValue(FilePathProperty); }
        set { SetValue(FilePathProperty, value); }
    }
    
    private static object CoerceFilePath(DependencyObject d, object value)
    {
        return value;
    }
    
    private static bool ValidateFilePath(object Value)
    {
        return true;
    }
    
    private static void OnChangedFilePath(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
    }
     
    public static readonly DependencyProperty FilePathProperty =
    	DependencyProperty.Register("FilePath", typeof(string), typeof(ClassName),
    	new PropertyMetadata(@"C:\File.avi", OnChangedFilePath, CoerceFilePath),
    	new ValidateValueCallback(ClassName.ValidateFilePath));
