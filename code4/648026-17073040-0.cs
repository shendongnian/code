    private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
    {
        DataGridViewRow dr = dataGridView1.SelectedRows[0];
        textBox1.Text = dr.Cells[0].Value.ToString();
         // or simply use column name instead of index
        //dr.Cells["id"].Value.ToString();
        textBox2.Text = dr.Cells[1].Value.ToString();
        textBox3.Text = dr.Cells[2].Value.ToString();
        textBox4.Text = dr.Cells[3].Value.ToString();
    }
