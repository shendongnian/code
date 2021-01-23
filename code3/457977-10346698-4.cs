    public string MyObjectInfoString 
    {
        get
        {
            return this.myObject.InfoString;
        }
        set
        {
            if (this.myObject.InfoString == value)
            {
                return;
            }
            this.myObject.InfoString = value;
            RaisePropertyChanged("MyObjectInfoString");
        }
    }
