    GridView myGridView = new GridView();
    myGridView.AllowsColumnReorder = false;
    
    ListView l1 = new ListView();
    
    GridViewColumn gvc0 = new GridViewColumn();
    gvc0.DisplayMemberBinding = new Binding("AA");
    gvc0.Header = "A/A";
    gvc0.Width = 30;
    myGridView.Columns.Add(gvc0);
    
    GridViewColumn gvc1 = new GridViewColumn();
    gvc1.Header = "Description";
    gvc1.Width = 300;
    FrameworkElementFactory fef = new FrameworkElementFactory(typeof(TextBlock));
    FrameworkElementFactory hyperlinkHolder = new FrameworkElementFactory(typeof(Hyperlink));
    hyperlinkHolder.SetBinding(Hyperlink.NavigateUriProperty, new Binding("Description"));
    hyperlinkHolder.AddHandler(Hyperlink.RequestNavigateEvent, new RequestNavigateEventHandler(Hyperlink_RequestNavigate));
    FrameworkElementFactory fef2 = new FrameworkElementFactory(typeof(TextBlock));
    Binding placeBinding = new Binding();
    fef2.SetBinding(TextBlock.TextProperty, placeBinding);
    placeBinding.Path = new PropertyPath("Description");
    hyperlinkHolder.AppendChild(fef2);
    fef.AppendChild(hyperlinkHolder);
    var dataTemplate = new DataTemplate();
    dataTemplate.VisualTree = fef;
    dataTemplate.DataType = typeof(ListViewItem);
    gvc1.CellTemplate = dataTemplate;           
    myGridView.Columns.Add(gvc1);
    
    l1.View = myGridView;
