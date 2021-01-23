    [DataMember]
    public string Id
    {
        get
        {
             return Guid.NewGuid().ToString();
        }
        private set {}
    }
