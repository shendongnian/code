    public Image MainIcon 
    { 
        get
        { return mainIcon; };
        set
        {
          mainIcon.Source = new BitmapImage(new Uri(value));
        };
    }
    public Image StatusIcon 
    {
        get
        { return statusIcon; };
        set
        {
          statusIcon.Source = new BitmapImage(new Uri(value));
        };
    }
    public MultiImage()
    {
        InitializeComponent();
    }
