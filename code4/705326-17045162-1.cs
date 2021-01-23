    using System.Threading.Tasks;
    using System.Windows;
    namespace WpfApplication4
    {
    	/// <summary>
    	/// Interaction logic for MainWindow.xaml
    	/// </summary>
    	public partial class MainWindow : Window
    	{
    		private readonly MainViewModel mainViewModel = new MainViewModel();
    
    		public MainWindow()
    		{
    			InitializeComponent();
    			DataContext = mainViewModel;
    			
    			//Just to start the operation in the background
    			Loaded += (sender, args) => Task.Factory.StartNew(() => mainViewModel.Start());
    		}
    	}
    }
