    private void button1_Click(object sender, EventArgs e)      
    {   
        if (textBox1.Text.Trim().Length == 0) 
        { 
            MessageBox.Show("Don't Leave this field blank!"); 
            return;
        } 
        using(SqlConnection con = new SqlConnection(
              "Server=DAFFODILS-PC\\SQLEXPRESS;Database=Library;Trusted_Connection=True;");      
        {
            SqlCommand sql1 = new SqlCommand("INSERT into Book " + 
                               "VALUES(@text1, @text2,@dtValue", con);      
            sql1.Parameters.AddWithValue("@text1", textBox1.Text);
            sql1.Parameters.AddWithValue("@text2", textBox2.Text);
            sql1.Parameters.AddWithValue("@dtValue", dateTimePicker1.Value.ToShortDateString());
            con.Open();      
            sql1.ExecuteNonQuery();      
            this.bookTableAdapter.Fill(this.booksDataSet.Book);      
            MessageBox.Show("Data Added!");      
            this.Close();      
      
        }      
    }
