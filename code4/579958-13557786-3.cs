     /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<MyListItem> _yourCollection = new ObservableCollection<MyListItem>();
    
        public MainWindow()
        {
            InitializeComponent();
            YourCollection.Add(new MyListItem { Title = "Item 1", Image = new BitmapImage(new Uri("C:\\Users\\Dev\\Pictures\\Picture1.PNG", UriKind.RelativeOrAbsolute)) });
            YourCollection.Add(new MyListItem { Title = "Item 2", Image = new BitmapImage(new Uri("C:\\Users\\Dev\\Pictures\\Picture2.PNG", UriKind.RelativeOrAbsolute)) });
        }
    
        public ObservableCollection<MyListItem> YourCollection
        {
            get { return _yourCollection; }
            set { _yourCollection = value; }
        }
    }
    
    public class MyListItem
    {
        public string Title { get; set; }
        public BitmapImage Image { get; set; }
    }
