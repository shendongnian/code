     private void LoadData()
    {
        DataSource ds = DataDriverExample.Select("Select * from XYZ");
        bs.DataSource = ds;
        dataGridView.DataSoure = bs;
        dataGridView.DataMember = "TableResult";
        txtAbc.Bindings.Add("text",bs,"TableResult.Col1");
     }
