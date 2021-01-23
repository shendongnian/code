    private proxy.ServicesClient client = null;
    private void LoadData()
    {
        App.Instance.SetBusy();
    
        client = new proxy.ServicesClient();
        client.GetCustomersCompleted += (s, e) =>
        {
            if (e.Error != null)
            {
                throw new Exception();
            }
            else
            {
                Customers = new ObservableCollection<CustomerModel>();
    
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
    
                OnPropertyChanged("Customers");
            }
            client.Close();//Close after the return
            App.Instance.UnSetBusy();
        };
        client.GetCustomersAsync();
        //client.Close();
    }
    }
