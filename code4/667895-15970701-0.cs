            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0 AttachDbFilename=C:\Users\h8005267\Desktop\Practical Project\Build\System4\System\StockControl.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Product WHERE ProductID=@ProductID", connection);
                cmd.Parameters.AddWithValue("@ProductID", textBox3.Text);
                SqlDataReader re = cmd.ExecuteReader();
                if (re.Read())
                {
                    textBox4.Text = re.GetString(re.GetOrdinal("ProductTitle")); // only fills using first product in table
                    textBox5.Text = re.GetString(re.GetOrdinal("ProductPublisherArtist"));
                    comboBox1.Text = re.GetString(re.GetOrdinal("ProductType"));
                    textBox6.Text = re.GetString(re.GetOrdinal("Price"));
                }
                else
                {
                    MessageBox.Show("Please enter a valid item barcode");
                }
                re.Close();
            }
