    obsListOfClients = new ObservableCollection<ClientVM>();
    foreach (var c in contexte.listOfClients)
    {
        ClientVM cvm = new ClientVM(c);
        // NEW BIT HERE
        cvm.PropertyChanged += ClientVMChangedEventHandler;
        obsListOfClients.Add(cvm);
    }
    obsListOfClients.CollectionChanged += ...;
    public void ClientVMChangedEventHandler(object sender, ...)
    {
        contexte.ListOfClientsToUpdate.Add(sender);
    }
