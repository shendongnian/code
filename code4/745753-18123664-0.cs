    public void ChangeCellEmail(int emailColumnIndex, string emailValue = "")
    {
      foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
      {
        dataGridView1.Rows[cell.RowIndex].Cells[emailColumnIndex].Value = emailValue;
      }
    }
