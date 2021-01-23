    public decimal Value
    {
        get{ return _value; }
        set
        {
            _value = value;
            textBox1.Text = _value.ToString();
        }
    }
