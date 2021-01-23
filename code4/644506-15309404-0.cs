       public class MovieModels
        {    
            public int id { get; set; }
            public string name { get; set; }
    
            [ForeignKey("UserProfile")]
            public int UserId
            {
                get { return WebSecurity.CurrentUserId; }            
            }
        }
