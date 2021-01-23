    DataTable dt = new DataTable("Row Order Checker");
    dt.Columns.Add("Identifier", typeof(int));
    dt.Columns.Add("GroupByMe");
    dt.Columns.Add("DataForEditing");
    
    dt.Rows.Add(1, "1", "data 1");
    dt.Rows.Add(2, "1", "data 2");
    dt.Rows.Add(3, "1", "data 3");
                
    SortDescriptor sortDescriptor = new SortDescriptor();
    sortDescriptor.Member = "Identifier";
    sortDescriptor.SortDirection = ListSortDirection.Ascending;
    gridView.SortDescriptors.Add(sortDescriptor);
    
    gridView.ItemsSource = dt.AsDataView();
