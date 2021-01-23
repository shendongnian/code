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
