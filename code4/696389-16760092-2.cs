    for (int f = 0; f < gridOperations.Rows.Count-1; f++)
    {
         for (int z = 0; f < gridOperations.ColumnCount -1; z++)
         {
              MessageBox.Show(gridOperations.Rows[f].Cells[z].Value.ToString());
         }
    }
