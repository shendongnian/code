    public partial class ListViewTest : Window
    {
        ObservableCollection<GameData> _GameCollection = 
            new ObservableCollection<GameData>();
        public ListViewTest()
        {
            _GameCollection.Add(new GameData { 
              GameName = "World Of Warcraft", 
              Creator = "Blizzard", 
              Publisher = "Blizzard" });
            _GameCollection.Add(new GameData { 
              GameName = "Halo", 
              Creator = "Bungie", 
              Publisher = "Microsoft" });
            _GameCollection.Add(new GameData { 
              GameName = "Gears Of War", 
              Creator = "Epic", 
              Publisher = "Microsoft" });
    
            InitializeComponent();
    
            this.DataContext = this;   //important part
        }
        public ObservableCollection<GameData> GameCollection
        { get { return _GameCollection; } }
    
        private void AddRow_Click(object sender, RoutedEventArgs e)
        {
          _GameCollection.Add(new GameData { 
              GameName = "A New Game", 
              Creator = "A New Creator", 
              Publisher = "A New Publisher" });
        }
    }
