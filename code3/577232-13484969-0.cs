    public bool MyProperty
    {
        get { return myField; }
        set
        {
            if (myField != value)
            {
                myField= value;
                NotifyPropertyChanged();
            }
        }
    }
