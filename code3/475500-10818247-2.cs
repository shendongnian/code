      public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}
		public void AddControl()
		{
			var l = new Label
			{
				Content = "Label",
				Height = 28,
				HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
				Margin = new Thickness(209, 118, 0, 0),
				Name = "label1",
				VerticalAlignment = System.Windows.VerticalAlignment.Top
			};
			Grid.Children.Add(l);
		}
		private void Grid_Loaded(object sender, RoutedEventArgs e)
		{
			Task.Factory.StartNew(() =>
			{
				Dispatcher.Invoke(new Action(AddControl), null);
			});
		}
	}
