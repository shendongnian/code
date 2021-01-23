    public class BeckhoffActuatorViewModel : MvxViewModel
    {
        public BeckhoffActuatorViewModel(string short)
        {
            ShortValue = short;
        }
    
        private string _shortValue;
        public string ShortValue
        {
            get
            {
                return _shortValue;
            }
            set
            {
                _shortValue = value;
                FirePropertyChanged("ShortValue");
            }
        }
    }
