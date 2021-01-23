    class ClockViewModel  // DataContext of ListBoxItem
    {
        public double Frequency { get; set; }
        public ICommand SetFrequency
        {
            get
            {
                return new DelegateCommand((obj) => { 
                  double freq = this.Frequency; 
                  // ...
                });
            }
        }
    }
    class WindowViewModel 
    {
        ObservableCollection<ClockViewModel> clocks_ = 
            new ObservableCollection<ClockViewModel>();
        public ObservableCollection<ClockViewModel> Clocks {get {return clocks_;}}
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var viewModel = new WindowViewModel();
            viewModel.Clocks.Add(new ClockViewModel() { Frequency = 10.123 });
            viewModel.Clocks.Add(new ClockViewModel() { Frequency = 42.0 });
            viewModel.Clocks.Add(new ClockViewModel() { Frequency = 3.14 });
            DataContext = viewModel;
        }
    }
