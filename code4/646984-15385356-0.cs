    private void button1_Click(object sender, EventArgs e)
        {
            string str = System.Environment.MachineName;
            SqlConnection sconn = new SqlConnection("Data Source='" + str + "';Initial Catalog=main;Integrated Security=True");
            sconn.Open();
            DataSet ds = new DataSet();
            for(int i=0; i< dataGridView1.Rows.Count;i++)
                {
                    SqlDataAdapter da = new SqlDataAdapter("insert into demo values('" + dataGridView1.Rows[i].Cells[0].Value + "','" + dataGridView1.Rows[i].Cells[1].Value + "','" + dataGridView1.Rows[i].Cells[2].Value + "')",sconn);
                        da.Fill(ds, "main");
                      
                        
                      
            conn.Close();
  }                                                
