    class ClockViewModel
    {
        public double Frequency { get; set; }
    }
    class WindowViewModel
    {
        ObservableCollection<ClockViewModel> clocks_ = new ObservableCollection<ClockViewModel>();
        public ObservableCollection<ClockViewModel> Clocks
        {
            get { return clocks_; }
        }
        public ICommand SetFrequency
        {
            get{
                return new DelegateCommand((obj) => 
                { 
                    var clock = obj as ClockViewModel;
                    DoSendBufStuffWithFrequency(clock.Frequency);
                });}
        }
        private void DoSendBufStuffWithFrequency(double frequency)
        {
        }
    }
