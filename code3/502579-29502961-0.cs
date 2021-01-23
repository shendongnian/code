    foreach (Profile p in this.localProfile)
    {
      DataGridViewRow row = new DataGridViewRow();
      row.CreateCells(this.dataGridView1);
      DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)row.Cells[1];
      cell.Items.Clear();
      cell.Items.Add(p.Address);
      row.Cells[0].Value = p.Name;
      row.Cells[1].Value = p.Address;
      row.Cells[2].Value = p.Port;
      this.dataGridView1.Rows.Add(row);
    }
