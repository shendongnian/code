    public interface IActivationEmailer {
        void SendActivationEmail();
    }
    
    public class CustomRegister
    {        
        private IActivationEmailer m_emailer;
    
        public CustomRegister(IActivationEmailer emailer){
           // store emailer to field
           m_emailer = emailer;
        }
    
        protected abstract bool IsUserExist(){...}
    
        protected abstract notifyUSer() {this.m_emailer.SendActivationEmail();}
        protected abstract performRegistration(){...}
    }
