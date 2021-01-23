    // Create new Checkbox Column
    DataGridViewCheckBoxColumn myCheckedColumn = new DataGridViewCheckBoxColumn()
            {
                Name = "Checked Column"
            };
    // add the new column to your dataGridView 
    myDataGridView.Columns.Add(myCheckedColumn);
