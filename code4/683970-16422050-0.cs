    foreach (DataColumn dc in results.Columns)
    {
        GridViewColumn gvCol = new GridViewColumn(); 
        gvCol.DisplayMemberBinding = new Binding(dc.ColumnName);        
        gvCol.Header = results.Columns[j].ColumnName;
        gvCol.Width = 200;     
        gv.Columns.Add(gvCol); 
        j++;           
    }
    lbVysledky.View = gv;
