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
                    int price = (Int32) cmd.ExecuteScalar();
                    textBox3.Text = price.ToString();
                    con.Close();
                }
            }
        }
