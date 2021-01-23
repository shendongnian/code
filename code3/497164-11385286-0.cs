    public MainPage()
    {
        InitializeComponent();
        var textBox = new TextBox
        {
            AcceptsReturn = true,
            Height = Double.NaN,
            TextWrapping = TextWrapping.Wrap
        };
        var stackPanel = new StackPanel();
        stackPanel.Children.Add(textBox);
        this.LayoutRoot.Children.Add(stackPanel);
    }
