    public class VoucherEntity: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void FirePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private CustomerEntity _customer;
        public CustomerEntity Customer
        {
            get {return _customer;}
            set
            {
                if (_customer != value)
                {
                    _customer= value;
                    FirePropertyChanged("Customer");
                }
            }
        }
    }
