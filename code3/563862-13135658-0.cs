    //the two classes can live in the same code file, if you want.
    private class ClientExtraDataClass
    {
        public string ExtraField1 { get; set; }
       public string ExtraField2 { get; set; }
    }
    private class newClient
    {
        public int ID { get; set; }
        public string Name{ get; set; }
    
        //you may want to make it a readonly property too, 
        // it depends on your needs.
        public ClientExtraDataClass ClientExtraData = new ClientExtraDataClass();
    }
