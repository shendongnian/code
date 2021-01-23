        private void btninsert_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("insert into Empinfo values ('" + textBox1.Text + "''" + textBox2.Text + "''" + textBox3.Text + "''" + textBox4.Text + "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Insert the record");
                cmd.Dispose();
            }
            catch(Exception e1)
                {
                    MessageBox.Show("e1");
                }
                finally
            {
            
            con.Close();
        
        }
        }
