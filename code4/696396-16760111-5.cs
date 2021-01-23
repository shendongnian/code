    for (int f = 0; f < gridOperations.Rows.Count; f++)
    {
         for (int z = 0; z < gridOperations.Rows[f].Cells.Count; z++)
         {
              MessageBox.Show(gridOperations.Rows[f].Cells[z].Value.ToString());
         }
    }
