    public partial class MainWindow : Window, INotifyPropertyChanged
    	{
    		public MainWindow()
    		{
    			this.InitializeComponent();
    		}
    
    		private string _txt;
    		public string txt
    		{
    			get
    			{
    				return _txt;
    			}
    			set
    			{
    				if (_txt != value)
    				{
    					_txt = value;
    					OnPropertyChanged("txt");
    				}
    			}
    		}
    
    		private void Button_Click(object sender, RoutedEventArgs e)
    		{
    			txt = "changed text";
    		}
    
    		public event PropertyChangedEventHandler PropertyChanged;
    
    		protected void OnPropertyChanged(string propertyName)
    		{
    			if (PropertyChanged != null)
    			{
    				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    			}
    		}
    	}
