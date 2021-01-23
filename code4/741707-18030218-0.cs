    var dataTable = ((DataTable)dataGridView1.DataSource).GetChanges();
    if(dataTable != null && dataTable.Rows.Count > 0)
    {
      foreach (DataRow row in dataTable.Rows)
            {
                switch (row.RowState)
                {
                    case DataRowState.Added:
                        // DO INSERT QUERY
                        break;
                    case DataRowState.Deleted:
                        // DO DELETE QUERY
                        break;
                    case DataRowState.Modified:
                        // DO UPDATE QUERY
                        break;
                }
            }
        ((DataTable)dataGridView1.DataSource).AcceptChanges();
    }
