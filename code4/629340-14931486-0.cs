    Queue<string> _customersQueue = new Queue<string>();
    bool _fetching;
    void SelectedCustomerEvent(string customer)
    {
        _customersQueue.Enqueue(customer);
        //.......
        if (!_fetching)
        {
            DoFetchCustomer(_customersQueue.Dequeue());
        }
    }
    void DoFetchCustomer(string customer)
    {
        _fetching = true;
        _wcfserviceagent.GetCustomer(customer, callback);
    }
    void callback(ObservableCollection<CustomerType> customer)
    {
        _fetching = false;
        //do some action
        if (_customersQueue.Count > 0)
        {
            DoFetchCustomer(_customersQueue.Dequeue());
        }
    }
