    [DataContract(IsReference = true)]
    [KnownType(typeof(NFS1))]
    [KnownType(typeof(NFS2))]
    abstract public class NFS : INFS 
    {
      [DataMember]
      abstract public string Path { get; set; }
    
      // the rest of code here
    }
    
    public class NFS1 : NFS {}
    public class NFS2 : NFS {}
