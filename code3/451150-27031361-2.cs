    String searchValue = "somestring";
    int rowIndex = -1;
    foreach(DataGridViewRow row in DataGridView1.Rows)
    {
        if (row.Cells["SystemId"].Value != null) // Need to check for null if new row is exposed
        {
            if(row.Cells["SystemId"].Value.ToString().Equals(searchValue))
            {
                rowIndex = row.Index;
                break;
            }
        }
    }
