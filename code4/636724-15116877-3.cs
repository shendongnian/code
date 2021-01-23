    obsListOfClients = new ObservableCollection<ClientVM>();
    foreach (var c in contexte.listOfClients)
    {
        ClientVM cvm = new ClientVM(c);
        // NEW BIT HERE
        cvm.PropertyChanged += ClientVMChangedEventHandler;
        obsListOfClients.Add(cvm);
    }
    obsListOfClients.CollectionChanged += ...;
    private void ClientVMChangedEventHandler(object sender,
                                             PropertyChangedEventArgs e)
    {
        contexte.ListOfClientsToUpdate.Add(((ClientVM)sender).Client);
    }
