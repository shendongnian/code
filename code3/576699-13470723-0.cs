    private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = string.Format("screenId like '%{0}%'", textBox1.Text.Trim().Replace("'", "''"));
            catch (Exception) { }
    
        }
