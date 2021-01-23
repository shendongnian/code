    [DataContract]
    public class Book { }
    
    [DataContract]
    public class Magazine { }
    
    [DataContract]
    [KnownType(typeof(Book))]
    [KnownType(typeof(Magazine))]
    public class LibraryCatalog
    {
        [DataMember]
        System.Collections.Hashtable theCatalog;
    }
