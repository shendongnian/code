    public static readonly DependencyProperty PageHeaderProperty = DependencyProperty.Register("PageHeader", typeof(string), typeof(YOUROWNER), new PropertyMetadata(""));
    
    public string PageHeader
    {
    	get { return GetValue(PageHeaderProperty) as string; }
    	set { SetValue(PageHeaderProperty, value); }
    }
