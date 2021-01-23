    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
    dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
    for (int i = 0; i < dataGridView.Columns.Count; i++)
    {
       dataGridView.Columns[i].Visible = false;
    }
