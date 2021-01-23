      private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Index")
            {
                ((DataTable)dataGridView1.DataSource).DefaultView.Sort = "Index, Subindex";
            }
        }
