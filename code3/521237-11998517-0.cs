        private AddressType _MySelectedItem;
        public AddressType MySelectedItem
        {
            get { return _MySelectedItem; }
            set
            {
                _MySelectedItem = value;
                OnPropertyChanged("MySelectedItem");
                CallMethodToEnableNextListBox(_MySelectedItem);
            }
        }
