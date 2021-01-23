    public class JobSeekerBO
    { 
       string _username = string.Empty;
       string _password= string.Empty;      
    
       public string Username
       {
            get { return _username; }
            set { _username = value; }
       }        
       public string Password
       {
            get { return _password; }
            set { _password = value; }
       }    
    }
