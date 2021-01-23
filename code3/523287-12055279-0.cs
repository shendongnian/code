    [DataContract(IsReference = true)]
    abstract public class NFS : INFS 
    {
      [DataMember]
      abstract public string Path { get; set; }
    
      // the rest of code here
    }
