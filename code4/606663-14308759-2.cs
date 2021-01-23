    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Shuffle(GameGrid.Children);
        }
    
        private void Shuffle(UIElementCollection list)
        {
            Random rand = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rand.Next(n + 1);
                Button value = list.OfType<Button>().ElementAt(n);
                list.Remove(value);
                list.Insert(k, value);
            }
        }
    }
