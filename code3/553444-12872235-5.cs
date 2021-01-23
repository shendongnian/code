    class ClockViewModel  // DataContext of ListBoxItem
    {
        public double Frequency { get; set; }
        public ICommand SetFrequency
        {
            get
            {
                return new DelegateCommand((obj) => { 
                  double freq = this.Frequency; // each buttons viewmodel has its frequency 
                });
            }
        }
    }
    class WindowViewModel  // DataContext of ListBox
    {
        ObservableCollection<ClockViewModel> clocks_ = 
            new ObservableCollection<ClockViewModel>();
        public ObservableCollection<ClockViewModel> Clocks { get { return clocks_; } }
    }
    void SomeMethodThatInitializeAndShowsYourWindow()
    {
        // Example. Your real application will probably collect 
        // data from business layer or dal...
        var viewModel = new WindowViewModel();
        viewModel.Clocks.Add(new ClockViewModel() { Frequency = 10.123 });
        viewModel.Clocks.Add(new ClockViewModel() { Frequency = 42.0 });
        viewModel.Clocks.Add(new ClockViewModel() { Frequency = 3.14 });
        var window = new YourWindowWithListBox();
        window.DataContext = viewModel;
        window.Show();
    }
