    public MyPageConstructor()
    {
        this.InitializeComponent();
        this.itemGridView.Loaded += (s,e) => itemGridView_Loaded(s, e);
    }
    private void itemGridView_Loaded(object sender, RoutedEventArgs e)
    {
        var myobject = // get object
        this.itemGridView.ScrollIntoView(myobject);
    }
