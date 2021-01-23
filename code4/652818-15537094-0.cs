    public interface IClientDAL
    {
        string ConnString { get; set; }
    
        ClientEntity NewClient(ClientEntity client);
        //...
    } 
