    [DataContract]
    [KnownType(typeof(CompositeType))]
    public class UserData 
    {
       [DataMember]
       public uint One { get; set; }
    
       [DataMember]
       public CompositeType Extra { get; set; }
    
       public UserData() { ctor. code }
    }
