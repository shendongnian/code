        public ChatBubbleDirection _Direction;
        public ChatBubbleDirection Direction
        {
            get
            {
                return _Direction;
            }
            set
            {
                if (value != _Direction)
                {
                    _Direction = value;
                    NotifyPropertyChanged("Direction");
                }
            }
        }
