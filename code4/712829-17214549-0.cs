    interface IClient
    {
         Client Retrieve(string clientId);
         bool Save(Client client);
         bool Delete(string clientId);
    }
