    public string MyName
    {
        get { return (string)this.GetValue(MyNameProperty); }
        set { this.SetValue(MyNameProperty, value); }
    }
