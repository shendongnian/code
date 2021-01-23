    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public List<string> AllNumbers { get; set; }
        private List<string> _bnumbers = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            AllNumbers = new List<string>();
            // Bingo game 75 numbers, 5x5 grid
            for (int i = 0; i < 75; i++)
            {
                AllNumbers.Add(i.ToString());
            }
        }
        public List<string> BNumbers
        {
            get { return _bnumbers; }
            set { _bnumbers = value; NotifyPropertyChanged("BNumbers"); }
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            RandomizeList(AllNumbers);
            BNumbers = AllNumbers.Take(25).ToList();
        }
        private void RandomizeList<T>(IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
