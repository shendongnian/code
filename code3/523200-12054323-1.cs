    [WebBrowsable(true),
     Category("category"),
     Personalizable(PersonalizationScope.Shared),
     WebDisplayName("Hello"),
     WebDescription("Description1"),
    WebPartStorage(Storage.Shared)] 
    public string Hello{ get; set;}
