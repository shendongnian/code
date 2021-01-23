    public decimal Value
    {
        get{ return _value; }
        set
        {
            _value = value;
            this.Text = _value.ToString();
        }
    }
