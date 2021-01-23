    private void button4_Click(object sender, EventArgs e)
        {
            String st = "DELETE FROM supplier WHERE supplier_id =" + textBox1.Text;
            SqlCommand sqlcom = new SqlCommand(st, myConnection);
            try
            {
                sqlcom.ExecuteNonQuery();
                MessageBox.Show("刪除成功");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void button6_Click(object sender, EventArgs e)
        {
            String st = "SELECT * FROM suppliers";
            SqlCommand sqlcom = new SqlCommand(st, myConnection);
            try
            {
                sqlcom.ExecuteNonQuery();
                SqlDataReader reader = sqlcom.ExecuteReader();
                DataTable datatable = new DataTable();
                datatable.Load(reader);
                dataGridView1.DataSource = datatable;
                //MessageBox.Show("LEFT OUTER成功");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
