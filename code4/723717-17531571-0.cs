    public partial class MainWindow : Window, INotifyPropertyChanged
    {
    	public MainWindow()
    	{
    		InitializeComponent();
    
    		this.DataContext = this;
    	}
    	
    	private bool _isOn;
    	public bool IsOn
    	{
    		get { return _isOn; }
    		set { _isOn = value; OnPropertyChanged("IsOn"); }
    	}
    	
    	private void Button_Click(object sender, RoutedEventArgs e)
    	{
    		IsOn = !IsOn;          
    	}
    
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	public void OnPropertyChanged(string propName)
    	{
    		PropertyChangedEventHandler handler = PropertyChanged;
    		if (handler != null)
    			handler(this, new PropertyChangedEventArgs(propName));
    	}
    }
