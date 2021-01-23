    public partial class MainWindowView : Window
    {
    	public MainWindowView()
    	{
    		InitializeComponent();
    		DataContext = new MainWindowViewModel();
    	}
    }
