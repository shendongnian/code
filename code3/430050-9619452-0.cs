    private void RemoveButton_Click_1(object sender, EventArgs e) // removes checked tasks.
    {
        List<int> rowsToRemove = new List<int>();
        int i = 0;
        for (i = 0; i <= TaskTable.Rows.Count - 1; i++)
        {
            if (TaskTable.Rows[i].Cells[0].Value != null)
            {
                if ((bool)TaskTable.Rows[i].Cells[0].Value == true)
                {
                    rowsToRemove.Add(i);
                }
            }
        }
        if (MessageBox.Show("Are you sure you want to remove the selected tasks?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) // confirmation
        {
            // delete rows in reverse order of row index so row indexes are preserved
            foreach (int rowIndex in rowsToRemove.OrderByDescending(x=>x))
            {
                TaskTable.Rows.RemoveAt(rowIndex); 
            }
            
        }
        TaskDataSet.WriteXml(fileURL);
        TaskDataSet.AcceptChanges(); // re writes xml file and removes deleted tasks.
    }
