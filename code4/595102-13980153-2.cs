    public XmlDataProvider MyXmlDataSource
    {
        get { return (XmlDataProvider)GetValue(MyXmlDataSourceProperty); }
        set { SetValue(MyXmlDataSourceProperty, value); }
    }
    // Using a DependencyProperty as the backing store for MyXmlDataSource.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty MyXmlDataSourceProperty =
        DependencyProperty.Register("MyXmlDataSource", typeof(XmlDataProvider), typeof(MainWindow), new UIPropertyMetadata(null));
