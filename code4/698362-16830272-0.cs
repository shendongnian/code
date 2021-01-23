    public List<UserDetails> GetUserDetails()
            {
                XDocument xDOC = XDocument.Load(Application.StartupPath+"\\load.xml");
                List<UserDetails> retVal = (from xele in xDOC.Descendants("User")
                                            select new UserDetails
                                            {
                                                UserName = xele.Element("username").Value,
                                                Password = xele.Element("password").Value
                                            }).ToList<UserDetails>();
    
                return retVal;
    
            }
        }
        
        public class UserDetails
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }
