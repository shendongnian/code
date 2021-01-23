    public class UserDetails
    {
        private dynamic _internal;
        public static implicit operator System.Dynamic.ExpandoObject(UserDetails details)
        {
            return details._internal;
        }
        public UserDetails()
        {
            _internal = new System.Dynamic.ExpandoObject();
        }
        public string UserID 
        { 
            get
            {
                return _internal.UserID;
            }
            set
            {
                _internal.UserID = value;
            }
        }
        public string UserName
        { 
            get
            {
                return _internal.UserName;
            }
            set
            {
                _internal.UserName = value;
            }
        }
    }
