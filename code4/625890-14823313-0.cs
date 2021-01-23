    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            ValidationRules = new ValidationRules();
        }
        private ValidationRules _validation;
        public ValidationRules ValidationRules
        {
            get { return _validation; }
            set { _validation = value; NotifyPropertyChanged("ValidationRules"); }
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
    public class ValidationRules : INotifyPropertyChanged
    {
        string email = "";
        public string EmailAddress
        {
            get
            {
                return email;
            }
            set
            {
                Console.WriteLine("Setting!");
                //Only check if there is any text for now...
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new Exception();
                }
                email = value;
                NotifyPropertyChanged("EmailAddress");
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
