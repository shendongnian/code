    public interface IActivationEmailer {
        void SendActivationEmail();
    }
    public abstract class Register:IRegister
    {        
        private IActivationEmailer m_emailer;
        protected Register(IActivationEmailer emailer){
           // store emailer to field
           m_emailer = emailer;
        }
        public string RegisterUser(string email, string password)
        {
            //Call IsUserExist and m_emailer.SentActivationEmail method internally
        }
    
        protected abstract bool IsUserExist();
    
    }
