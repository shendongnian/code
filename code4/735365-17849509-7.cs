    namespace MyCustomExtensionService
    {
        public class UserAccessAttribute : System.Attribute
        {
            private string _userRole;
    
            public UserAccessAttribute(string userRole)
            {
                _userRole = userRole;
                
                //you could also put your role validation code in here
                
            }
    
            public string GetUserRole()
            {
                return _userRole;
            }
        }
    }
