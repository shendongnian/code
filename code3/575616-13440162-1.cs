    public bool MyBoolProperty
    {
        get { return  myBoolField; }
        set
        {
            myBoolField = value;
            NotifyPropertyChanged();
        }
    }
