       if (textBox1.Text != "" & textBox2.Text != "")  
       {  
            string queryText = "SELECT Count(*) FROM Table1 " + 
                               "WHERE username = @Username AND password = @Password";
            using(SqlConnection cn = new SqlConnection("your_connection_string"))
            using(SqlCommand cmd = new SqlCommand(queryText, cn))
            {
                cn.Open();  
                cmd.Parameters.AddWithValue("@Username", textBox1.Text);  // cmd is SqlCommand 
                cmd.Parameters.AddWithValue("@Password", textBox2.Text);  
                int result = (int)cmd.ExecuteScalar();
                if (result > 0)  
                    MessageBox.Show("Loggen In!");  
                else
                    MessageBox.Show("User Not Found!");  
            }
        }  
