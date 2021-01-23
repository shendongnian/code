    public class CustomerViewMode : ModelBase
    {
        public CustomerViewMode()
        {
            LoadCustomer = null; //load customer from service, database, repositry, etc.
            SaveCustomer = null; //save customer to service, database, repositry, etc.
        }
        private Customer _CurrentCustomer;
        public Customer CurrentCustomer
        {
            get { return _CurrentCustomer; }
            set
            {
                if (_CurrentCustomer == value)
                    return;
                _CurrentCustomer = value;
                OnPropertyChanged();
            }
        }
        public ICommand LoadCustomer { get; private set; }
        public ICommand SaveCustomer { get; private set; }
    }
