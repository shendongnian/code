    private void button_refresh_Click(object sender, EventArgs e)
            {
                SqlConnection con=new SqlConnection(@"");
                string query="select * from abc";
                SqlCommand cmd=new SqlCommand(query,con);
                SqlDataAdapter da=new SqlDataadapter(cmd);
                DataTable dt=new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource=dt;
            }
