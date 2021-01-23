    string query = "SELECT * FROM catalog";
    using (MySqlConnection con  = new MySqlConnection (connectionString))
    {
     con.Open();
     using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query , con))
     {
      DataSet ds = new DataSet();
      dataAdapter.Fill(ds);
      dataGridView1.DataSource = ds.Tables[0];
     }
     con.Close();
    }
        
