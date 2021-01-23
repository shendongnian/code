    private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
      for (int i = 0; i < DataGridView1.Rows.Count; i++) {
        DataGridViewRow row = DataGridView1.Rows[i];
        if (row.Cells[0].Value == DataGridView1.Rows[e.RowIndex].Cells[0].Value) {
          DataGridView1.Rows.RemoveAt(e.RowIndex);
          DataGridView1.FirstDisplayedScrollingRowIndex = e.RowIndex;
          return;
        }
      }
    }
