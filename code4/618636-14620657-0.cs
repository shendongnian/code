    private void button1_Click(object sender, EventArgs e)
        {
            string conStr = "Data Source=PC-303\\SQLEXPRESS;Initial Catalog=sokaklar;User ID=sa;Password=*****";
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT DISTINCT IL, IL_ID FROM sokaklar ORDER BY IL", new SqlConnection(conStr));
            DataTable dt = new System.Data.DataTable();
            adapter.Fill(dt);            
            comboBox1.DisplayMember = "IL";
            comboBox1.ValueMember = "IL_ID";
            comboBox1.DataSource = dt;            
        }
