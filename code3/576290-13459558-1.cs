    public class User : emUser
    {
        #region Properties
        public string Username
        {
            get { return Email; }
        }
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
        #endregion
    
        public static explicit operator User (emUser user) 
        {
            User result = new User();
            // set properties
            return result;
        }
    }
