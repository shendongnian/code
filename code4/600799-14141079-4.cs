    ICommand ModifyVideoCountCommand { get; set; }
    ObservableCollection<VideoPlayer> VideoPlayerCollection { get; set; }
    int GridSize 
    {
        get
        {
            return Math.Ceiling(Math.Sqrt(VideoPlayerCollection.Count));
        }
    }
