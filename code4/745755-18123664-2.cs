    public void ChangeCellEmail(int emailColumnIndex, string[] emails)
    {
      var emailsAsCsv = string.Join(";", emails.Where(e => !string.IsNullOrWhiteSpace(e)));
      foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
      {
        dataGridView1.Rows[cell.RowIndex].Cells[emailColumnIndex].Value = emailsAsCsv;
      }
    }
