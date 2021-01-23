    public StackPanel InfoPane { get; set; }
    public MainWindow()
    {
        InitializeComponent();
        InfoPane = new StackPanel();
        InfoPane.Children.Add(new TextBlock { Text = "dynamically created" });
        this.DataContext = this;
    }
