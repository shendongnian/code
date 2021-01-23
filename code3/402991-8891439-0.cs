    private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
            {
                if (dataGridView1.Columns[e.ColumnIndex].HeaderText =="day")
                {
                   myBindingSource.Sort = "day, hour";
                }
            }
