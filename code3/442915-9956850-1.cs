    public delegate void OnAddTable(DataTable dataTable);
    private void AddTable(DataTable dataTable)
    {
        if(this.InvokeRequired) 
        {
            this.BeginInvoke(new OnAddTable(AddTable), new object[] {dataTable}));
            return;
        }
        for (int i = 0; i < dataTable.Rows.Count; i++) 
        { 
            comboBox.Items.Add(dataTable.Rows[i][0].ToString()); 
        }
    } 
