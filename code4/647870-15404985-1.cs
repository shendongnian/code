    Form2 f2 = new Form2();
                    
        int selectedCellCount = dataGridView1.GetCellCount(DataGridViewElementStates.Selected);
        
        if (selectedCellCount > 0)
        {
        for (int i = 0; i < selectedCellCount; i++)
            {
               int column = dataGridView1.SelectedCells[i].ColumnIndex;
               int row = dataGridView1.SelectedCells[i].RowIndex;
               f2.PassVal = dataGridView1[column, row].Value.ToString();
            }
        }
        f2.Show();
