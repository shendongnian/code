    public class MyViewModel : INotifyPropertyChanged
    {
        private Customer _selectedCustomer;
        public List<Customer> Customers { get; set; }
        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                if (_selectedCustomer == value)
                    return;
                _selectedCustomer = value;
                OnPropertyChanged("SelectedCustomer");
            }
        }
        public void MoveSelectionLeft()
        {
            if (SelectedCustomer == Customers.First())
                return;
            var selCustomerIndex = Customers.IndexOf(SelectedCustomer);
            SelectedCustomer = Customers[selCustomerIndex - 1];
        }
        public void MoveSelectionRight()
        {
            if (SelectedCustomer == Customers.Last())
                return;
            var selCustomerIndex = Customers.IndexOf(SelectedCustomer);
            SelectedCustomer = Customers[selCustomerIndex + 1];
        }
        public MyViewModel()
        {
            Customers = new List<Customer>
                {
                    new Customer {Name = "John", Age = 25},
                    new Customer {Name = "Jane", Age = 27},
                    new Customer {Name = "Dawn", Age = 31}
                };
            SelectedCustomer = Customers.First();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
