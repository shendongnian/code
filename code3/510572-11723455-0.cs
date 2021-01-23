    public partial class MainWindow : Window {
        private ObservableCollection<Player> players_;
        
        public MainWindow() {
            InitializeComponent();
            players_ =new ObservableCollection<Player> () {
                new Player() {
                    name = "Alex",
                    nrOfTabls = 1,
                },
                new Player() {
                    name = "Brett",
                    nrOfTabls = 2,
                },
                new Player() {
                    name="Cindy",
                    nrOfTabls = 231,
                }
            };
            ListBox_Players.ItemsSource = players_;
        }
    }
