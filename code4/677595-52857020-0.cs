    private void MoveUpDown(bool goUp)
        {
            int newRowIndex = DataGridView.SelectedCells[0].OwningRow.Index + (goUp ? -1 : 1);
            if (newRowIndex > -1 && newRowIndex < DataGridView.Rows.Count)
            {
                DataGridView.ClearSelection();
                DataGridView.Rows[newRowIndex].Selected = true;
            }
        }
