    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.Games = new Games();    // this will execute the Games constructor 
                                         // and add the games to Games
        }
    
        // allows you to use 'Games' in your xaml
        public ObservableCollection<Game> Games  
        {
            get;
            set;
        }
    
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
