    private void LoadData()
    {
        //Activate BudyIndicator
        App.Instance.SetBusy();
    
        BackgroundWorker worker = new BackgroundWorker();
        worker.DoWork += (o, ea) =>
        {
            ObservableCollection<CustomerModel> LoadedCustomers = null;
    
            //Create Client
            proxy.ServicesClient client = new proxy.ServicesClient();
    
            client.GetCustomersCompleted += (s, e) =>
            {
                if (e.Error != null)
                {
                    throw new Exception();
                }
                else
                {
                    LoadedCustomers = new ObservableCollection<CustomerModel>();
                    foreach (var item in e.Result)
                    {
                        Customers.Add(new CustomerModel()
                        {
                            CustomerId = item.CustomerId,
                            Title = item.Title,
                            FirstName = item.FirstName,
                            MiddleName = item.MiddleName,
                            LastName = item.LastName,
                            CompanyName = item.CompanyName,
                            SalesPerson = item.SalesPerson,
                            EmailAddress = item.EmailAddress,
                            Phone = item.Phone
                        });
                    }
                }
            };
            client.GetCustomersAsync();
            client.Close();
    
            //Define return value
            ea.Result = LoadedCustomers;
        };
        worker.RunWorkerCompleted += (o, ea) =>
        {
            //Get returned value
            ObservableCollection<CustomerModel> model = ea.Result as ObservableCollection<CustomerModel>;
            if (model != null)
            {
                Customers = model;
            }
    
            //Desactivate BudyIndicator
            App.Instance.UnSetBusy();
        };
        worker.RunWorkerAsync();
    }
