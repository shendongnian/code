    public MainWindow()
    {
        InitializeComponent();
        Button button = new Button() { Height = 80, Width = 150, Content = "Test" };
        //In case you want to add other controls;
        //You should still really use XAML for this.
        var grid = new Grid();
        grid.Children.Add(button);
        Content = grid;
    }
