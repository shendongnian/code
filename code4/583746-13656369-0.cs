    Remove()
    // You can use an array/list or whatever you want below.
    Collection<DataGridViewRow> rowsToDelete = new Collection<DataGridViewRow>();
            for (int i = 0; i < ConGridView.RowCount; i++)
            {
                 if (ConGridView.Rows[i].Cells[0].Value.ToString() == Address)
                    {
                            rowsToDelete.Add(ConGridView.Rows[i]);
                            break;
                    }
            }
           // now remove the marked entries.
           foreach(DataGridViewRow deletedRow in rowsToDelete)
           {
               ConGridView.Rows.Remove(deletedRow);
           }
