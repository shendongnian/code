    protected void DataGrid1_ItemCreated(object sender, DataGridItemEventArgs e){
        for(int i = 0; i < e.Item.Cells.Count; i++){
            e.Item.Cells[i].Attributes.Add("title", DataGrid1.Columns[i].HeaderText);
        }
    }
