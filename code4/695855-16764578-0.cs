    private void dgvKlanten2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e) {
          int rows = ds1.Tables["Klanten"].Rows.Count;
          //when loading
          if (e.RowIndex == rows  - 1) {
            dgvKlanten2.Rows[e.RowIndex+1].Cells[2].Value = "add a record here";
            dgvKlanten2.Rows[e.RowIndex+1].Cells[2].Style.ForeColor = Color.Gray;
          }
    
          //when adding a new row
          if (e.RowIndex > rows ) {
            dgvKlanten2.Rows[rows].Cells[1].Value = getNieuwKlantNummer();
            dgvKlanten2.Rows[e.RowIndex].Cells[2].Value = "add a record here";
            dgvKlanten2.Rows[e.RowIndex].Cells[2].Style.ForeColor = Color.Gray;
            dgvKlanten2.Rows[e.RowIndex-1].Cells[2].Style.ForeColor = Color.Black;
            dgvKlanten2.Rows[e.RowIndex-1].Cells[2].Value = String.Empty;
          }
        }
