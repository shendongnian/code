    private void leavestat()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string query = "SELECT * FROM leaverecord";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                 listBox1.Items.Add(dt.Columns[i].ToString());
            }
                conn.Close();
        }
