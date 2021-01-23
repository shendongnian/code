    private void button1_Click(object sender, EventArgs e)
            {
                sqlConnection1.Open();
                sqlCommand1.Parameters.AddWithValue("@user",textBox1.Text);
                sqlCommand1.Parameters.AddWithValue("@pass",textBox2.Text);
                sqlCommand1.CommandText = "SELECT id,parola FROM ANGAJAT WHERE id='@user' AND    parola='@pass'";
                if (sqlCommand1.ExecuteNonQuery()!=null)
                    MessageBox.Show("ESTE");
                sqlConnection1.Close();
            }
