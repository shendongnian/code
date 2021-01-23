    private void DataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
    {
      addDataGridDND(dgActiveProblems, true);
      foreach (DataRow row in _dtProblemList.Rows)
      {
         row.EndEdit()
         if (row.RowState == DataRowState.Modified)
         {
              passivate();
         }
      }
    }
