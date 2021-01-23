    public abstract class Register:IRegister
    {        
        public string RegisterUser(string email, string password)
        {
            if (this.IsUserExist())
            {
            //throw the error
            }
            else
            {
             this.performRegistration();
             this.notifyUSer();
            }
        }
    
        protected abstract bool IsUserExist();
    
        protected abstract notifyUSer();
         
        protected abstract performRegistration(){}
    }
