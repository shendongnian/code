    public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}
		private void btnLoad_Click(object sender, RoutedEventArgs e)
		{
			tb.Text = File.ReadAllText(@"*path to file*");
		}
	}
