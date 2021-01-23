    public static readonly DependencyProperty DisplayNameProperty = DependencyProperty.Register("DisplayName", typeof(string), typeof(mycontrol));
    
    public string DisplayName
    {
        get { return GetValue(DisplayNameProperty).ToString(); }
        set { SetValue(DisplayNameProperty, value); }
    }
