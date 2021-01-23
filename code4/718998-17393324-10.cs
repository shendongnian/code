    public class ChatEntry:PropertyChangedBase
    {
        public DateTime DateTime { get; set; }
        private string _content;
        public string Content
        {
            get { return _content; }
            set
            {
                _content = value;
                OnPropertyChanged("Content");
            }
        }
        public string Sender { get; set; }
    }
