    private void RemoveButton_Click(object sender, EventArgs e)
    {
        List<DaraGridViewRow> rowsToRemove = new ...
        foreach (DataGridViewRow item in this.TaskTable.SelectedRows)
        {
            if (item.Cells[0].Value != null)
            {
                if ((bool)item.Cells[0].Value == true)
                {
                    if (MessageBox.Show(...) // confirmation
                    {
                        rowsToRemove.Add(item);
                    }
                }
            }
        }
        foreach(var row in rowsToRemove)
        {
              this.TaskTable.Rows.Remove(row);
        }
        // write xml
        // accept changes
    }
