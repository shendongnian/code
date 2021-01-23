    struct NewItem
    {
        private string _displayMember;
        private string _value;
        public NewItem(string displayMember, string value)
        {
            _displayMember = displayMember;
            _value = value;
        }
        public string DisplayMember
        {
            get
            {
                return _displayMember;
            }
        }
        public string Value
        {
            get
            {
                return _value;
            }
        }
    }
