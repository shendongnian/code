    protected override void OnRender(DrawingContext drawingContext)
    {
        if (ISFirstRender)
        {
            TabItem tabitem = new TabItem();
            tabitem.Header = "Tab 3";
            pan1.Items.Add(tabitem);
            MyUserControl userControl = new MyUserControl();
            tabitem.Content = userControl;
            ISFirstRender = false;
        }
        base.OnRender(drawingContext);
    }
