    [XmlRoot("MessageRoot", Namespace = "", IsNullable = false)]
    public class MessageRoot
    {
        [XmlElement(IsNullable = true, ElementName = "message")]
        public string Message { get; set; }
        [XmlArray("messageList")]
        [XmlArrayItem("message")]
        public string[] Messages { get; set; }
    }
 
       <MessageRoot>   
         <message> message </message>  
         <messageList>
           <message>message1</message>
           <message>message2</message>   
          </messageList>  
       </MessageRoot> 
