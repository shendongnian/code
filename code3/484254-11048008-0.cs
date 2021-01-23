    [DataContract(Name = "baseClass")]
    [KnownType(typeof(busObj1))]
    [KnownType(typeof(busObj2))]
    [KnownType(typeof(busObj3))]
    [KnownType(typeof(busObj4))]
    public class baseClass { }
    
    [DataContract(Name = "busObj1")]
    public class busObj1 : baseClass { }
    
    [DataContract(Name = "busObj2")]
    public class busObj2 : baseClass { }
    
    [DataContract(Name = "busObj3")]
    public class busObj3 : busObj1
    {
        public busObj2 myObj { get; set; }
    }
    
    [DataContract(Name = "busObj4")]
    public class busObj4 : busObj3 { }
