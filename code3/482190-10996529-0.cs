    [DataContract] 
    [KnownType(typeof(SitecoreItem))]
    public class Item{
         [DataMember]
         public int ID{get; set;}
         [DataMember]
         public string Name{get; set;} }
    
    [DataContract] 
    public class SitecoreItem : Item{
         [DataMember]     
         public DbType SitecoreInstance{get; set;} 
    }
