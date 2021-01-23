    public static readonly DependencyProperty FoldersProperty = DependencyProperty.Register("Folders", typeof(OutlookFolders), typeof(MainWindow), new FrameworkPropertyMetadata(new OutlookFolders()));
    public OutlookFolders Folders
    {
        get { return GetValue(FoldersProperty) as OutlookFolders; }
        set { SetValue(FoldersProperty, value); }
    }
