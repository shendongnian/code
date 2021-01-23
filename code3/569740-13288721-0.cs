        public static List<Message> _SessionStore;
        public static List<Message> SessionStore
        {
            get
            {
                if(HttpContext.Current.Session["MyData"]==null)
                {
                    _SessionStore = new List<Message>();
                }
                return _SessionStore;
            }
            set 
            { 
                HttpContext.Current.Session["MyData"] = value;
                _SessionStore = value;
            }
        }
