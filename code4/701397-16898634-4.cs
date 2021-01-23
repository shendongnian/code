    public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			DataContext = new RootViewModel
			{
				X = 5,
				Y = 7
			};
		}
	}
