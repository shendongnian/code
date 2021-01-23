        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                MessageBox.Show("Null String !!!!!!!!");
                return;
            }
            SqlConnection con = new SqlConnection("Server = DAFFODILS-PC\\SQLEXPRESS;Database=Library;Trusted_Connection=True;");
            SqlCommand sql1 = new SqlCommand("INSERT into Book VALUES('" + textBox1.Text + "' , '" + textBox2.Text + "','" + dateTimePicker1.Value.ToShortDateString() + "')", con);
            con.Open();
            sql1.ExecuteNonQuery();
            con.Close();
            this.bookTableAdapter.Fill(this.booksDataSet.Book);
            MessageBox.Show("Data Added!");
            this.Close();
        }
