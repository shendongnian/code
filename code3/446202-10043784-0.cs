    Messenger.Default.Register<CustomerSavedMessage>(this, message =>
    {
         Application.Current.Dispatcher.Invoke(
             new Action(() => Customers.Add(message.UpdatedCustomer))); 
    });
