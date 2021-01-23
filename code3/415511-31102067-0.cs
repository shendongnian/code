     con.Open();
     string query = "insert_demo";
        /* date  fromat Stored*/
     TextBox2.Text = DateTime.Now.ToLongDateString();
     SqlCommand com = new SqlCommand(query, con);
     com.CommandType = CommandType.StoredProcedure;
     com.Parameters.AddWithValue("@Name", TextBox1.Text.ToString());
     com.Parameters.AddWithValue("@Date", TextBox2.Text.ToString());
     com.ExecuteNonQuery();
