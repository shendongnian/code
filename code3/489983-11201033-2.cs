        int columnIndex = dgvC.SelectedCells[0].ColumnIndex;
        if (dgvC.SelectedCells.Cast<DataGridViewCell>().Any(r => r.ColumnIndex != columnIndex))
        {
            //Not same
        }
        else
        {
            //Same
        }
