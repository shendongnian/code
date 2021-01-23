    public Form2(DataGridView dgvFromFom1) {
      InitializeComponent();
      foreach (DataGridViewColumn dc in dgvFromForm1.Columns) {
        dataGridView1.Columns.Add(dc.Name, dc.HeaderText);
      }
      foreach (DataGridViewRow dr in dgvFromForm1.Rows) {
        Object[] newRow = new object[dr.Cells.Count];
        for (int i = 0; i < newRow.Length; i++) {
          newRow[i] = dr.Cells[i].Value;
        }
        dataGridView1.Rows.Add(newRow);
      }      
    }
