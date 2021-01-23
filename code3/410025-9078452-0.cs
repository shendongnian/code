    [DataContract]
        public class User : IValidatableObject
        {
            [DataMember]
            public Dictionary<Role,AccessLevel> Roles
            {
                get; set;
            }
        }
    [DataContract]       
    public class Role
         {           
            [DataMember]
            public Int32 Id { get; set; }
    
            [DataMember]
            public String Name { get; set; }
                
            [DataMember]
            public Dictionary<User,AccessLevel> Users
            {
               get;set;
           }
    }
