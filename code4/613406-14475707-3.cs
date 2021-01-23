     private void LoadData()
    {
        bs.ResetBinding(true);
        txtAbc.DataBindings.Clear()
        DataSource ds = DataDriverExample.Select("Select * from XYZ");
        bs.DataSource = ds;
        dataGridView.DataSoure = bs;
        dataGridView.DataMember = "TableResult";
        txtAbc.Bindings.Add("text",bs,"TableResult.Col1");
     }
