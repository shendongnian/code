    [OperationContract]
    public Client[] GetClients()
    {
        List<Client> clients = new DB().RetrieveClients();
        return clients.ToArray();
    }
