            Boolean allCells = true;
            int colIndex = dgvC.SelectedCells[0].ColumnIndex;
            foreach (DataGridViewCell c in dgvC.SelectedCells)
            {
                if(c.ColumnIndex != colIndex)
                {
                    allCells = false;
                }
            }
            if(allCells)
            {
                //do stuff here
            }
