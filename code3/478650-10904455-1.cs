    StringBuilder sb = new StringBuilder();
    foreach (DataGridViewCell cell in dgvC.SelectedCells)
    {
        sb.AppendLine(cell.Value.ToString()); 
    }
    MessageBox.Show(sb.ToString());
