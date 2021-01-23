    [DataContract]
    public class Salesman
    {
       
        [DataMember(Name = "a")]
        public virtual string Id { get; set; }
        [DataMember(Name = "b")]
        public virtual int RoleId { get; set; }
        [DataMember(Name = "c")]
        public virtual string Name { get; set; }
        [DataMember(Name = "d")]
        public virtual string Address { get; set; }
        [DataMember(Name = "e")]
        public virtual string Phone { get; set; } 
    } // "a","b","c","d"... are the values with which you'll identify the object properties - client side - when json parsing.
 
     [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
        [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
        public class SalesmanService 
        {
    
            [OperationContract]
            [WebGet(UriTemplate = "/get/{id}", 
                RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
            public Salesman Get(string id)
            {
              //return your salesman
            }
        }
