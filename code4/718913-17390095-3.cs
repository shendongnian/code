    public class User : BaseNotify
    {
    
        private string userName;
        public string UserName 
        { 
        
            get { return userName; }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }
    }
