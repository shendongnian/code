    public static readonly DependencyProperty = 
        DependencyProperty.Register("PersonName", typeof(string), typeof(MyUserControl), null);
    public string DisplayText { get; set; }
    public string PersonName
    {
        get { return (string)GetValue(PersonNameProperty); }
        set { SetValue(PersonNameProperty, value); }
    }
