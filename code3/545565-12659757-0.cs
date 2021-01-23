    public string Texting
        {
            get { return _Texting; }
            set
            {
                _Texting = value;
                OnPropertyChanged("Texting");
                throw new StackOverflowException("BAM!");
            }
        }
