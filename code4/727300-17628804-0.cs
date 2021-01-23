    public MainWindow()
    {
        InitializeComponent();
        MyMediaElement.MediaFailed += MyMediaElement_MediaFailed;
        MyMediaElement.LoadedBehavior = MediaState.Play;
        MyMediaElement.Source = 
            new Uri(@"http://somesite/somevideo.mp4", UriKind.Absolute);
    }
    void MyMediaElement_MediaFailed(object sender, ExceptionRoutedEventArgs e)
    {
        MessageBox.Show(e.ErrorException.Message);
    }
