    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
    {
         col.Name = "opchrg";
         col.HeaderText = "ColumnName";
         opchrg.DefaultCellStyle.ForeColor = Color.White;
         opchrg.HeaderCell.Style.BackColor = Color.Red;//Column Header Color
         this.dataGridView1.Columns.Add(col);
    }
