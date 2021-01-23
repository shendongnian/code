    public static readonly DependencyProperty PageProperty =
        DependencyProperty.Register("Page", typeof(Page), typeof (ViewModel), new PropertyMetadata(null));
    public Page Page
    {
        get { return (Page) GetValue(PageProperty); }
        set { SetValue(PageProperty, value); }
    }
