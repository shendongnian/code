        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            System.Windows.Forms.SortOrder ss = dataGridView1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection;
            string strColumnName = dataGridView1.Columns[e.ColumnIndex].Name;
            label8.Text = "Column: " + strColumnName + " - " + "sort order: " + ss.ToString();
        }
