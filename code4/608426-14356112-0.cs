        public class CurrentCustomer
        {
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public string Email { get; set; }
        
                private string _Token;
                public string Token
                {
                    get
                    {
                        return _Token;
                    }
                    set
                    {
                        _Token = value;
                    }
                }
         }
