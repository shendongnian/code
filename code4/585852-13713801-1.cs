    public class Comment : INotifyPropertyChanged
    {
        private string username;
        private string comment;
        public comment(string _username, string _comment)
        {
            this.Username = _username;
            this.Comment = _comment;
        }                 
        
        public string Username
        {
            get
            {
                return username;
            }
            
            set
            if(value != username)
            {
                username = value;
                NotifyPropertyChanged("Username");
            }
        }                   
        
        publicc string Comment
        {
            get
            {
                return username;
            }
            
            set
            if(value != username)
            {
                username = value;
                NotifyPropertyChanged("Username");
            }
        }       
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
    
