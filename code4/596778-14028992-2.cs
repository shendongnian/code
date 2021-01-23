    private string _errors = "";
    public string Errors
    {
        get { return this._errors; }
        set
        {
            if(_errors != value)
            {
                _errors = value;
                RaisePropertyChanged("Errors");
            }
        }
    }
