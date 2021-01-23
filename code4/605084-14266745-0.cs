    [Serializable]
    public class SessionInfo
    {
        // Stuff to store in session
        public string Name { get; set; }
        public int Foo { get; set; }
    
        private SessionInfo()
        {
            // Constructor, set any defaults here
            Name = ""
            Foo = 10;
        }
    
        public static SessionInfo Current
        {
            get
            {
                // Try get session info from session
                var info = HttpContext.Current.Session["SessionInfo"] as SessionInfo;
                
                // Not found in session, so create and store new session info
                if (info == null)
                {
                    info = new SessionInfo();
                    HttpContext.Current.Session["SessionInfo"] = info;
                }
    
                return info;
            }
        }
    }
