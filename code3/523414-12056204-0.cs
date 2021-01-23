    [DataContract]  
    public class InstagramCaption {
  
       [DataMember(Name = "text")]
       public string Text {get; set;}
       
    } 
    . . . 
      [DataMember(Name = "caption")]     
      public InstagramCaption caption { get; set; }     
    . . . 
      
