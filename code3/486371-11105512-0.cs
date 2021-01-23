    void proxy_FindProfileCompleted(object sender, FindProfileCompletedEventArgs e)
    {             
        ListBox1.ItemsSource = e.Result;
        ObservableCollection<Customer> Customers = 
            this.ListBox1.ItemsSource as ObservableCollection<Customer>;  
        foreach(Customer cust in Customers)
        {
            // You can get cust.CustName
            // and you can get cust.CustEmail
        }
    }
