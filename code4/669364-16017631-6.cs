    private string _customerNameValue = String.Empty;
    public string CustomerName
    {
        get
        {
            return this._customerNameValue;
        }
    
        set
        {
            if (value != this._customerNameValue)
            {
                this._customerNameValue = value;
                NotifyPropertyChanged();
            }
        }
    }
    private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
