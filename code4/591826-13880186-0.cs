    public static readonly DependencyProperty VideoPlayerSourceProperty = DependencyProperty.Register("VideoPlayerSource", 
        typeof(System.Uri), typeof(Player),
        new PropertyMetadata(null, (dObj, e) => ((Player)dObj).OnVideoPlayerSourceChanged((System.Uri)e.NewValue)));
    public System.Uri VideoPlayerSource {
        get { return (System.Uri)GetValue(VideoPlayerSourceProperty); } // !!!
        set { SetValue(VideoPlayerSourceProperty, value); } // !!!
    }
    void OnVideoPlayerSourceChanged(System.Uri source) {
        mediaElement.Source = source;
    }
