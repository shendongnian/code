        private void btnMyButton_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn col in dgvMyGrid.Columns)
                dt.Columns.Add(col.Name.ToString());
            DataRow dr = dt.NewRow();
            foreach (DataGridViewCell cell in dgvMyGrid.SelectedRows[0].Cells)
                dr[cell.OwningColumn.Name] = cell.Value.ToString();               
        }
