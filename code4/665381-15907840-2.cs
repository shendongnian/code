    public string MyProp
    {
        get { return _myProp; }
        set
        {
            _mProp = value;
            OnPropertyChanged("MyProp");
            Messenger.PostMessage(new VMChangedMessage { ViewModel = this, PropertyName = "MyProp" });
        }
    }
