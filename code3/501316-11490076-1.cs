        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data source=.;initial catalog=loki;integrated security=true"))
            {
                string query = "select  price from metro where source= @Source and destination = @Destination";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Source", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Destination", textBox2.Text);
                    con.Open();
                    object o  = cmd.ExecuteScalar();
                    if(o != null && o != DBNull.Value)
                    {
                       string price = (string) o; //please cast the return type as required
                       textBox3.Text = price;
                    }
                    con.Close();
                }
            }
        }
