    public void SetUpDataGridView()
    {
        DataGridViewCellStyle style = dataGridView1.ColumnHeadersDefaultCellStyle;
        style.BackColor = Color.White;
        style.ForeColor = Color.Black;
        dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        dataGridView1.RowHeadersVisible = false;
        dataGridView1.Columns[0].HeaderText = "Sr.No";
        dataGridView1.Columns[0].Width = 50;
        // And so on for all the columns...
     
        dataGridView1.Columns[7].Width = 100;
        DataGridViewCheckBoxColumn column3 = new DataGridViewCheckBoxColumn();
        column3.Name = "Column3";
        column3.HeaderText = "IsCheck";
        column3.ReadOnly = false;
        dataGridView1.Columns.Add(column3);
    }
