    using System.Runtime.Serialization;
    [DataContract]
    public class Class {
     
       public Class(string code, string desc, string date) { 
          this.code = code;
          this.desc = desc;
          this.date = date;
       }
    
       [DataMember]
       public string Code { get;set; }
   
       [DataMember]
       public string Desc { get;set; }
  
       [DataMember]
       public string Date { get;set; }
    }
