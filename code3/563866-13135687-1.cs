    class newClient
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ClientExtraData clientExtraData{ get; set; }
        public newClient()
        {
            clientExtraData = new ClientExtraData();
        }
        
        internal class ClientExtraData
        {
            public string ExtraField1 { get; set; }
            public string ExtraField2 { get; set; }
        }
    }
