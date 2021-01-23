    public partial class GenrePage : PhoneApplicationPage
    {
      public GenrePage()
      {
        InitializeComponent();
      }
    
      protected override void OnNavigatedTo( NavigationEventArgs e )
      {
        base.OnNavigatedTo( e );
    
        string genreID = String.Empty;
        if( NavigationContext.QueryString.TryGetValue( "genreID", out genreID ) ) {
          LaunchWebClient( genreID );
        }
      }
    
      private void LaunchWebClient( string genreID )
      {
        WebClient jsonGenres = new WebClient();
        Uri apiGenre = new Uri( genreID );
        
        jsonGenres.DownloadStringCompleted += new 
          DownloadStringCompletedEventHandler( jsonGenres_GetDataCompleted );
        jsonGenres.DownloadStringAsync( apiGenre );
      }
    }
