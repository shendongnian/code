	using System.Threading.Tasks;
	using System.Windows;
	namespace WpfApplication4
	{
		public partial class MainWindow : Window
		{
			private MainViewModel mainViewModel;
			public MainWindow()
			{
				InitializeComponent();
				Loaded += (sender, args) => StartOperation();
			}
			private void Button_Click(object sender, RoutedEventArgs e)
			{
				StartOperation();
			}
			/// <summary>
			/// Start the long running operation in the background.
			/// </summary>
			private void StartOperation()
			{
				DataContext = mainViewModel = new MainViewModel();
				Task.Factory.StartNew(() => mainViewModel.Start());
			}
		}
	}
