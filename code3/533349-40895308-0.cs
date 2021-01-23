        private void btnretrive_Click(object sender, EventArgs e)
        {
            string cs = "server=localhost;user id=root;database=world;";
            SqlConnection conn = new SqlConnection(cs);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from world;",conn);
            SqlDataReader reader = cmd.ExecuteReader();
            
            DataTable table = new DataTable();
            table.Load(reader);
            dataGridView1.DataSource = table;
            conn.Close();
        }
