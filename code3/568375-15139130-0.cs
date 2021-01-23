    public class UsersIdentificationViewModel 
    {      
        public UserDetailsModel UserDetails { get; set; }        
        public UserInfoModel UsersInfo { get; set; }
        // I added this propery so I can round up the binding process in case the properties are simple types
        public string SomeSimpleProperty { get; set; }
    }
