    public class SecurityManager : UserNamePasswordValidator
    {
        //cacheCredentials stores username and password
        static Dictionary<string, string> cacheCredentials = new Dictionary<string, string>();
        //cacheTimes stores username and time that username added to dictionary.
        static Dictionary<string, DateTime> cacheTimes = new Dictionary<string, DateTime>();
        
        public override void Validate(string userName, string password)
        {
            if (userName == null || password == null)
            {
                throw new ArgumentNullException();
            }
            if (cacheCredentials.ContainsKey(userName))
            {
                if ((cacheCredentials[userName] == password) && ((DateTime.Now - cacheTimes[userName]) < TimeSpan.FromSeconds(30)))// &&  timespan < 30 sec - TODO
                    return;
                else
                    cacheCredentials.Clear();
            }
            if (Membership.ValidateUser(userName, password))
            {
                //cache usename(key) and password(value)
                cacheCredentials.Add(userName, password);
                //cache username(key), time that username added to dictionary 
                cacheTimes.Add(userName, DateTime.Now);
                return;
            }
            throw new FaultException("Authentication failed for the user");       
        }
    }
