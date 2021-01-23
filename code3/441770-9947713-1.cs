    public partial class MainWindow : Window
	{
		public ViewModel ViewModel { get; set; }
		public MainWindow()
		{
			ViewModel = new ViewModel();
			InitializeComponent();
		}
	}
