    public void SelectIdCell()
        {
            favorite_GridView.ClearSelection();
            foreach (DataGridViewCell cell in favorite_GridView.CurrentRow.Cells)
            {
                if (cell.Visible)
                {
                    cell.Selected = true;
                    return;
                }
            }
        }
