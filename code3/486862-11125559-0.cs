        private StatusMode _Status;
        [DataMember(Name = "Status")]
        public StatusMode Status
        {
            get { return _Status; }
            set 
            {
                _Status = value;
                OnPropertyChanged("Status");
                if (OnChanged != null)
                {
                    OnChanged();
                }
            } 
        }
