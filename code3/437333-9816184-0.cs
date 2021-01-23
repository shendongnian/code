    public int Value
    {
        get{ return value; }
        set{
            this.value = value;
            OnValueChanged("Value");
            OnValueChanged("AddressValue")
        }
    }
