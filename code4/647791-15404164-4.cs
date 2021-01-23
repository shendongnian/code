    public abstract class Message : ViewModelBase
    {
        private string _messageContent;
        public string MessageContent 
        {
            get
            {
                return this._messageContent;
            }
            set
            {
                this._messageContent = value;
                this.OnPropertyChanged("MessageContent");
            }
        }   
    }
