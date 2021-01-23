    private static ObservableCollection<Top> top= new ObservableCollection<Top>();
        private static ObservableCollection<string> place= new ObservableCollection<string>();
    	private string _url1;
    	private string _url2;
        // Constructor
        public MainPage(string url1, string url2)
        {
            InitializeComponent();
            if (NetworkInterface.GetIsNetworkAvailable())
            {
    		    _url1 = url1;
    			_url2 = url2;
                LoadSiteContent_A(url1);
            }
            else
                MessageBox.Show("No Internet Connection, please connect to use this applacation");
            listBox.ItemsSource = top; //trying to bind listbox after web calls
        }
    	
        public void LoadSiteContent_A(string url)
        {
                //create a new WebClient object
                WebClient clientC = new WebClient();
                clientC.DownloadStringCompleted += (sender, e) => { 
    			 string testString = "";
    			 if (!e.Cancelled && e.Error == null)
    			 {
    				 string str;
    				 str = (string)e.Result;
    				 //Various operations and parsing
    				place.Add(testString);
    				LoadSiteContent_B(_url2);
    			  }
    			};
    			
                clientC.DownloadStringAsync(new Uri(url));
        }
    
        public void LoadSiteContent_B(string url)
        {
                //create a new WebClient object
                WebClient clientC = new WebClient();
                clientC.DownloadStringCompleted += (sender, e) => {/*do whatever you need*/};
                clientC.DownloadStringAsync(new Uri(url));
        }
    
    
    public class TopUsers
    {
        public string TopUsername { get; set; }
        public int Place { get; set; }
    
        public TopUsers(string topusername, int place)
        {
            this.TopUsername = topusername;
            this.Place = place;
    
        }
    }
    
    
    }
