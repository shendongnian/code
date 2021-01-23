    public static readonly new DependencyProperty ContentProperty = DependencyProperty.Register("Content", typeof(object), typeof(YourClassName));
    public new object Content
    {
        get { return this.GetValue(ContentProperty); }
        set { this.SetValue(ContentProperty, value); }
    }
