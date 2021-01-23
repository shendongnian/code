        public class PlaylistItem
        {
            public string ItemName { get; set; }
            public string PlayListGroup { get; set; }
        }
        public MainPage()
        {
            InitializeComponent();
            List<PlaylistItem> PlayList = new List<PlaylistItem>();
            //Add your playlistitems in PlayList
            PlayList.Add(new PlaylistItem() { ItemName = "abc", PlayListGroup = "Vimeo Playlist" });
            PlayList.Add(new PlaylistItem() { ItemName = "ab", PlayListGroup = "Playlist" });
            var groupedPlayList =
                    from list in PlayList
                    group list by list.PlayListGroup into listByGroup
                    select new KeyedList<string, PlaylistItem>(listByGroup);
            PhotoHubLLS.ItemsSource = new List<KeyedList<string, PlaylistItem>>(groupedPlayList);
        }
