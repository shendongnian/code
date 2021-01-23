    private class NewClient
    {
            public class NewClient() 
            {
                this.ClientExtraData = new ClientData();
            }
            public int ID { get; set; }
            public string Name{ get; set; }
            public ClientData ClientExtraData {get;set;}
    }
