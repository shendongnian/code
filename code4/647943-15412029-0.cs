        public class ServiceResponse
        {
            private List<Exception> exceptions = new List<Exception>();
            public List<Exception> Errors { get { return exceptions; } }
            private string password;
            public string Password
            {
                get
                {
                    return password;
                }
                set
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        exceptions.Add(new ArgumentException("Password cannot be empty!"));
                    }
                    if (value != null && value.Length < 10)
                    {
                        exceptions.Add(new ArgumentException("Password is too short!"));
                    }
                    if (exceptions.Count == 0)
                    {
                        password = value;
                    }
                    //else throw an Exception that errors were occured or do nothing
                }
            }
        }
