    private ObservableCollection<Post> _posts;
    public ObservableCollection<Post> Posts
    {
        set
        {
            _posts = value;
            InvokePropertyChanged("Posts");
        }
        get { return _posts; }
    }
