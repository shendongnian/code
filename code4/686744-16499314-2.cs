    public string StringValue
    {
        get
        {
            return stringValue;
        }
        set
        {
            OnPriceChanged(new ValueChangedEventArgs(value));
            stringValue = value;
        }
    }
