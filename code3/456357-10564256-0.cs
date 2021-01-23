    [DataContract] 
    public class mainresponse
     {
     [DataMember]
     public resultmap arrayelement { get; set; }
     }  
     [DataContract]
     public class resultmap 
    {
     [DataMember] 
     public string substringhere { get; set; } 
     }     
     var djson = new DataContractJsonSerializer(typeof(Mainresponse));
     var stream = new MemoryStream(Encoding.UTF8.GetBytes(responsestring));
     mainresponse result = (mainresponse)djson.ReadObject(stream);  
