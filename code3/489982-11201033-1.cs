    int columnIndex = dgvC.SelectedCells[0].ColumnIndex;
    bool sameCol = true;
    for(int i=0;i<dgvC.SelectedCells.Count;i++)
        {
            if(dgvC.SelectedCells[i].ColumnIndex != columnIndex)
             {
               sameCol = false;
               break;
              }
         }
     if (sameCol)
         {
           MessageBox.Show("Same Column");
         }
      else
         {
           MessageBox.Show("Not same column");
         }
