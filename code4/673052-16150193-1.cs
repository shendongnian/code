    internal class MainWindowViewModel : Screen, IShell
    {
        Regex expression = new Regex(@"^N\d\.C\d\.D\d\.R\d:\s\s\s-\d"); //ex. "N1.C1.D2.R1:   -3"      
        // Declare your second VM as a property so you can bind to it via CM conventions  
        public SecondViewModel SecondView 
        { 
            get { return _secondView; } 
            set 
            {
                _secondView = value;
                NotifyOfPropertyChange(() => SecondView);
            }
        }
        public MainWindowViewModel()
        {
            SecondView = new SecondViewModel();
        }
