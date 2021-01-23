    public partial class AverageNumbersSample : Window
    {
        public double Average = 116.21428571428571;
        public List<AverageSampleViewModel> Values { get; set; } 
        public AverageNumbersSample()
        {
            InitializeComponent();
            DataContext = Values = Enumerable.Range(100, 150)
                                            .Select(x => new AverageSampleViewModel() { Value = x })
                                            .ToList();
        }
        private void Calculate(object sender, RoutedEventArgs e)
        {
            Values.ForEach(x => x.IsBelowAverage = x.Value < Average);
        }
    }
