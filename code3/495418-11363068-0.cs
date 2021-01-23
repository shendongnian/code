       [DataContract]
       public class Unicorn {   
  
        [DataMember (EmitDefaultValue=false)] 
        public string Id { get; set; }     
        [DataMember (EmitDefaultValue=false)] 
        public string Color { get; set; }     
        [DataMember (EmitDefaultValue=false)] 
        public int? Size { get; set; }     
        [DataMember (EmitDefaultValue=false)] 
        public DateTime? BirthDate { get; set; } 
    } 
