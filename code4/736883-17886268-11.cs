    public partial class MainWindow : Window
    {
    	public MainWindow()
    	{
    		InitializeComponent();
    
    		tweets = new Tweets();
    
    		tweets.Add(new Tweet("user1", "name1", "url1"));
    		tweets.Add(new Tweet("user2", "name2", "url2"));
    		tweets.Add(new Tweet("user3", "name3", "url3"));
    
    		this.DataContext = this;
    	}
    
    	public Tweets tweets { get; set; }
    
    	private void Button_Click(object sender, RoutedEventArgs e)
    	{          
    		tweets.Add(new Tweet("user4", "name4", "url4"));
    	}
    }
