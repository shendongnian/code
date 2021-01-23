        public string Text1
        {
            get { return _text1; }
            set
            {
                _text1 = value;
                RaisePropertyChanged("Text1");
            }
        }
