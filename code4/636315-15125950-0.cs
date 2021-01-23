     private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO userinfo (FirstName, LastName, Age, Address, Course)" + "VALUES (@First_Name, @Last_Name, @Age, @Address, @Course)";
                cmd.Parameters.AddWithValue("@First_Name", textBox1.Text);
                cmd.Parameters.AddWithValue("@Last_Name", textBox2.Text);
                cmd.Parameters.AddWithValue("@Age", textBox3.Text);
                cmd.Parameters.AddWithValue("@Address", textBox5.Text);
                cmd.Parameters.AddWithValue("@Course", textBox5.Text);
                cmd.Connection = conn;
                conn.Open();
                clear();
                cmd.ExecuteNonQuery();
                {
                    MessageBox.Show("Data Added!");
                    conn.Close();
                }
                dataholder();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
