    public string TestProperty{
        set
        {
            if(this._TestProperty == value)
            {
                return;
            }
            this._TestProperty = value;
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("TestProperty"));
            }            
        }
    }
