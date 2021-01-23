    obsListOfClients = new ObservableCollection<ClientVM>();
    foreach (var c in contexte.listOfClients)
    {
        ClientVM cvm = new ClientVM(c);
        // NEW BIT HERE
        cvm.PropertyChanged += new ClientVMChangedEventHandler(...);
        obsListOfClients.Add(cvm);
    }
    obsListOfClients.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(collectionOfClientssChanged);
