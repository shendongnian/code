	public MainWindow()
	{
		InitializeComponent();
		Loaded += OnLoaded;
	}
	private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
	{
		CustomPanel p = new CustomPanel();
		p.Children.Add(new Button(){Content = "T"});
		gr.Children.Add(p);
	}
