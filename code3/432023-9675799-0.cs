    public object MyProperty
    {
        get
        {
            return myField;
        }
        set
        {
            if (value != myField)
            {
                myField = value;
                NotifyProperyChanged("MyProperty"); // raise event
            }
        }
    }
