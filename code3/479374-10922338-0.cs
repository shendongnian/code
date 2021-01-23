    public class Message : System.Dynamic.DynamicObject
    {
        public Message(object data) { //parse data into defined properties and dictionary}
       
        public string MessageType {get;set;}
        //other "common" properties
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
           //binder.Name will hold the property name that is being accessed
           //if the value exists in the message, set it to the result parameter
           //and return true, else set it to null and return false (which will cause an Exception)
        }
        
    }
