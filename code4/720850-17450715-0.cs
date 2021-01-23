    public class MyPerson
    {
       [DataMember]
       public int ID {get; set;}
       [DataMember]
       public string Name {get; set;}
       ...
       [DataMember]
       public MyRole PersonRole {get; set;}
    }
    
    public class MyRole
    {
       [DataMember]
       public int ID {get; set;}
       ...
    }
