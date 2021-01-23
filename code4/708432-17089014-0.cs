        var buttonCol = new DataGridViewButtonColumn();
        buttonCol.Name = "ButtonColumnName";
        buttonCol.HeaderText = "Header";
        buttonCol.Text = "Button Text";
        
        dataGridView.Columns.Add(buttonCol);
        foreach (DataGridViewRow row in dataGridView.Rows)
    {
        DataGridViewButtonCell button = (row.Cells["ButtonColumnName"] as DataGridViewButtonCell);        
    }
