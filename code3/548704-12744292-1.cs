    private void selectedRowsButton_Click(object sender, System.EventArgs e)
    {
        Int32 selectedRowCount =
            dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
        if (selectedRowCount > 0)
        {
            for (int i = 0; i < selectedRowCount; i++)
            {
                // do something
            }
        }
    }
