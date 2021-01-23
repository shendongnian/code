    // Create new Checkbox Column
    DataGridViewCheckBoxColumn myCheckedColumn = new DataGridViewCheckBoxColumn()
            {
                Name = "Checked Column", FalseValue = 0 , TrueValue = 1 , Visible = true
            };
    // add the new column to your dataGridView 
    myDataGridView.Columns.Add(myCheckedColumn);
