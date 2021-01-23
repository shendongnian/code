    public class SessionManager
    {
        //Groups of variables
        public enum Groups
        {
            Users,
            Processes
        }
        //Value keys
        private static int USERID
        {
            get { return USERID"; }
        }
        private static string USERGUID
        {
            get { return "USERGUID"; }
        }
        //Properties        
        public String UserGuid
        {
            get { return this.session[USERGUID]; }
            set { this.session[USERGUID] = value; }
        }
	
	...
        //Finnish using values
        public bool Finnish(Groups group)
        {
            switch (group)
            {
                case Groups.Users:
                    this.Session.Remove(USERID);
                    this.Session.Remove(USERGUID);
                    break;
                case Groups.Processes:
                    this.Session.Remove(UP);
                    this.Session.Remove(DOWN);
                default:
                    return false;
            }
            return true;
        }
	...
    }
