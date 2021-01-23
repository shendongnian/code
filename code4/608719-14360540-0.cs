    public MainViewModel : INotifyPropertyChanged
    {
        // Should be full properties that implement INotifyPropertyChanged, 
        // but leaving that out for simplicity right now
        public ObservableCollection<object> Forms { get; set; }
        public object CurrentForm { get; set; }
        public ICommand SubmitCommand { get; set; }
        // Could also add ICommands for Back and Next buttons as well
    
        public MainViewModel()
        {
            Forms = new ObservableCollection()
            {
                new Form1Data(),
                new Form2Data(),
                new Form3Data(),
                new Form4Data(),
                new Form5Data()
            };
    
            CurrentForm = Forms.FirstOrDefault();
        }
    }
