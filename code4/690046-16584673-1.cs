    [RegularExpression(@"^[a-zA-Z''-'\s]{1,128}$", ErrorMessage = "AttributeName must contain no more then 128 characters and contain no digits.")]
    public string AttributeName
    {
        get { return _attributeName; }
        set
        {
            _attributeName = value;
            IsDirty = true;
            OnPropertyChanged("AttributeName");
        }
    }
