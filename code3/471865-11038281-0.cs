    [DataContract]
    public class Foo {  //Your model class
    
       [DataMember(Name="bar-none")]  //This also allows you to use chars like '-'
       public string bar {get; set;}
       
       [IgnoreDataMember]  //Don't serialize this one
       public List<string> fuzz { get; set;}
    
    }
