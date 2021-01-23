    public abstract class Register:IRegister
    {        
        public string RegisterUser(string email, string password)
        {
            //Call IsUserExist and SentActivationEmail method internally
        }
    
        protected abstract bool IsUserExist();
    
        protected abstract void SendActivationEmail();
    }
