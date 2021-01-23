        [Serializable]
        public class FullServiceAddressCorrectionDelivery
        {
            [XmlElement("AuthenticationInfo", 
                  Namespace = 
                  "http://www.usps.com/postalone/services/UserAuthenticationSchema")]
            public AuthenticationInfo AuthenticationInfo
            {
                get;
                set;
            }
        }
    
        [Serializable]
        public class AuthenticationInfo
        {
            [XmlElement("UserId", Namespace="")]
            public string UserId
            {
                get;
                set;
            }
            [XmlElement("UserPassword", Namespace = "")]
            public string UserPassword
            {
                get;
                set;
            }
        } 
