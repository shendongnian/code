        //Make sure you clear existing unboundcolumns
        foreach(string name in names)
        {
           int idx = gridView.Columns.Add(new GridColumn());
           gridView.Columns[idx].Visible = true;
           gridView.Columns[idx].Tag = name;
           gridView.Columns[idx].Caption = name;
           gridView.Columns[idx].UnboundType = UnboundColumnType.Integer;
        }
