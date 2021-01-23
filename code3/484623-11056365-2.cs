    public ObservableCollection<Customer> Customer
    {
        get { return _customer; }
        set
        {
            _customer = value;
            RaisePropertyChanged("Customer");
        }
    }
