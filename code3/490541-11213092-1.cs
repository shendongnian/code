    public partial class MainWindow : Window
    {
    
        ObservableCollection<MyViewModel> guys { get; set; }
    
        public MainWindow()
        {
            InitializeComponent();
            guys = new ObservableCollection<MyViewModel>();
            guys.Add(new MyViewModel { Name = "First Guy", Age = 21, FavoriteColor = "Blue" });
            guys.Add(new MyViewModel { Name = "Second Guy", Age = 22, FavoriteColor = "Red" });
            guys.Add(new MyViewModel { Name = "Third Guy", Age = 23, FavoriteColor = "Yellow" });
            guys.Add(new MyViewModel { Name = "Fourth Guy", Age = 24, FavoriteColor = "Green" });
            myGrid.ItemsSource = guys;
        }
    
        public class MyViewModel
        {
            public String Name { get; set; }
            public int Age { get; set; }
            public String FavoriteColor { get; set; }
        }
    
        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            guys.Add(new MyViewModel { Name = "[New Guy]", Age = 0, FavoriteColor = "[Color]" });
        }
    
    }
