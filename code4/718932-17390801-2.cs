            private void dataGridView1_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
            {
                
                Form2 f2 = new Form2();
                f2.textBox1.Text = dataGridView1.Rows[0].Cells[e.ColumnIndex].FormattedValue.ToString();
                f2.textBox2.Text = dataGridView1.Rows[1].Cells[e.ColumnIndex].FormattedValue.ToString();
                f2.Show();
            }
    
            private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
            {
                Form2 f2 = new Form2();
                f2.textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                f2.textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                f2.Show();
            }
