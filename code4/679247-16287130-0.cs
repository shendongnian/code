    GridView myGridView = new GridView();
    myGridView.AllowsColumnReorder = true;
    
    GridViewColumn gvc1 = new GridViewColumn();
    gvc1.DisplayMemberBinding = new Binding("ColumnOneHeader");
    gvc1.Header = "Column One Header";
    gvc1.Width = 100;
    myGridView.Columns.Add(gvc1);
    GridViewColumn gvc2 = new GridViewColumn();
    gvc2.DisplayMemberBinding = new Binding("Column2Header");
    gvc2.Header = "Column 2 Header";
    gvc2.Width = 100;
    myGridView.Columns.Add(gvc2);
    GridViewColumn gvc3 = new GridViewColumn();
    gvc3.DisplayMemberBinding = new Binding("ColumnThreeHeader");
    gvc3.Header = "Column Three Header";
    gvc3.Width = 100;
    myGridView.Columns.Add(gvc3);
    
    
    listView.View = myGridView;
