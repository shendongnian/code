        private string _Message;
        public string Message
        {
            get { return _Message; }
            set
            {
                _Message = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Message"));
            }
        }
