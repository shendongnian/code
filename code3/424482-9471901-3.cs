    public partial class MainPage : PhoneApplicationPage
    {
        private const string _key = "url";
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }
        //OnNavigatedTo method
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //if this page was activated from a tile it will contain a Querystring value of _key
            // launch a request for the current web address at the location indicated in the query string
            if (NavigationContext.QueryString.ContainsKey(_key))
            {
                string url = NavigationContext.QueryString[_key];
                TheBrowser.Navigate(new Uri(url));
            }
        }
        private void PinToStart_Click(object sender, RoutedEventArgs e)
        {
            string _url = url.Text;
            ShellTile TileToFind = ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains("url=" + _url));
            // Create the Tile if we didn't find that it already exists.
            if (TileToFind == null)
            {
                StandardTileData NewTileData = new StandardTileData
                {
                    BackgroundImage = new Uri("Background.png", UriKind.Relative),
                    Title = string.Format("link - {0}", _url),
                    Count = 1,
                    BackTitle = "Quest",
                    BackContent = (string)_url,
                    BackBackgroundImage = new Uri("", UriKind.Relative)
                };
                // Create the Tile and pin it to Start. This will cause a navigation to Start and a deactivation of our application.
                ShellTile.Create(new Uri("/MainPage.xaml?" + _key + "=" + _url, UriKind.Relative), NewTileData);
            }
            else
            {
                MessageBox.Show("Tile already exists");
            }
        }
    }
