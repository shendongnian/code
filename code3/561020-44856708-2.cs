    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
    {
         col.Name = "ColumnName";
         col.HeaderText = "HeaderName";
         col.DefaultCellStyle.ForeColor = Color.White;
         col.HeaderCell.Style.BackColor = Color.Red; //Column Header Color
         this.dataGridView1.Columns.Add(col);
    }
