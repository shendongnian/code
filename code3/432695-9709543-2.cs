    [Export(typeof(MenuItem)]
    [ExportMetadata("ContextTarget", "foo")]
    public FooMenuItemForBarAction
    {
        get
        {
            var menuItem = new MenuItem("BarAction");
            menuItem.Click += delegate
            {
                // code to handle click here
            }
            return menuItem;
        }
    }
