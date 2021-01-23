    public void SaveValue()
    {
        string val = GetValueFromDB();
        MyClass thisValue;
        lock (this.GlobalValue)
        {
            if (this.GlobalValue == NULL)
            {
                this.GlobalValue = new MyClass(val);
            }
            else if (this.GlobalValue.Key != val)
            {
                this.GlobalValue = new MyClass(val);
            }
            thisValue = this.GlobalValue
        }
        string result = thisValue.GetData();
    }
