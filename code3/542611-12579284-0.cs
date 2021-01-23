    using (var con = new SqlConnection(cstr))
      {
          SqlCommand cmd = new SqlCommand("insert", con);
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.Parameters.AddWithValue("@firstname", TextBox1.Text);
          cmd.Parameters.AddWithValue("@lastname", TextBox2.Text);
          cmd.Parameters.AddWithValue("@city", TextBox3.Text);
          con.Open();
         return cmd.ExecuteNonQuery();
      }
