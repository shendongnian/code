    public static readonly new DependencyProperty ContentProperty = DependencyProperty.Register("Content", typeof(object), typeof(Tile));
    public new object Content
    {
        get { return this.GetValue(ContentProperty); }
        set { this.SetValue(ContentProperty, value); }
    }
