    public class ViewModel : INotifyPropertyChanged
    {
        private string _stateText;
        
        public RelayCommand CalculationCommand { get; set; }
    
        public string StateText
        {
            get { return _stateText; }
            set { _stateText = value;  OnPropertyChanged("StateText");}
        }
    
        public ViewModel()
        {
            CalculationCommand = new RelayCommand(OnCalculate);
            StateText = string.Empty;
        }
    
        private void OnCalculate(object obj)
        {
            StateText = "Please wait, calculating.";
    
            var context = TaskScheduler.Current;
    
            Task.Factory.StartNew(() =>{
                                            //Calculating Logic goes here   
                                       }).ContinueWith(x =>
                                                           {
                                                               StateText = "Done.";
                                                           },context);
    
            
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
