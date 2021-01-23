    namespace App5
    {
        public parital class SongListControl : userControl
        {
            this.InitializeComponent();
            List Songs = new List();
            Songs.Add(new SongsData() { Title = "Your Song", Lyrics = "It's a little bit funny.." });
            Songs.Add(new SongsData() { Title = "Rocket Man", Lyrics = "I'm the Rocket Maaaan.." });
            SongsListBox.ItemsSource = Songs;
        }
    }
