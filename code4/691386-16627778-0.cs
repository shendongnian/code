    // [...]
    daOleDb.Fill(dtResult);
    DataColumn dtCol = new DataColumn("Bool", typeof(Boolean));
    dtCol.DefaultValue = false;
    dtResult.Columns.Add(dtCol);
    dtCol.SetOrdinal(0);
    DataGrid1.ItemsSource = dtResult.DefaultView;
