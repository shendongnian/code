    public class IntroScreen : Window, INotifyPropertyChanged
    {
    	private string[] files;
        private System.Timers.Timer timer;
    
        private int counter;
        private int Imagecounter;
    
        Uri _MainImageSource = null; 
    
        public Uri MainImageSource 
        {
            get 
            {
                return _MainImageSource; 
            } 
            set 
            {
                _MainImageSource = value;
    	        OnPropertyChanged("MainImageSource");
            } 
        }
    
        public IntroScreen()
        {
            InitializeComponent();
            DataContext = this;
            this.Loaded += new RoutedEventHandler(this.MainWindow_Loaded);
        }
    
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
    
            setupPics();
        }
    
        private void setupPics() 
        {
            timer = new System.Timers.Timer();
            timer.Elapsed += new ElapsedEventHandler(timer_Tick);
            timer.Interval = 2000;
            timer.Start();
    
            files = Directory.GetFiles("../../Resources/Taken/", "*.jpg", SearchOption.TopDirectoryOnly);
            Imagecounter = files.Length;
            MessageBox.Show(Imagecounter.ToString());
            counter = 0;
        }
    
        private void timer_Tick(object sender, EventArgs e)
        {
            counter++;
            _MainImageSource = new Uri(files[counter - 1], UriKind.Relative);
            if (counter == Imagecounter)
                {
                    counter = 0;
                }
        }
    	
    	
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	protected virtual void OnPropertyChanged(string propertyName)
    	{
    		PropertyChangedEventHandler handler = PropertyChanged;
    		if (handler != null)
    			handler(this, new PropertyChangedEventArgs(propertyName));
    	}
    }
