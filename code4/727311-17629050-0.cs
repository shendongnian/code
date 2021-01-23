    string query = "select bounty from provider where sirname = @name";
    double numericToDouble = 0;
    using (SqlConnection con = new SqlConnection(YourDB.ConnectionString)
    {
        using(SqlCommand cmd = new SqlCommand(query,con))
        {
            cmd.Parameters.AddWithValue(@name,"nameYouNeed");
            try{
              con.Open();
              SqlDataReader reader = cmd.ExecuteReader();
              if (reader.Read())
                 numericToDouble = Convert.ToDouble32(reader[0].ToString());
              con.Close();
            }
            catch(SqlError someError)
            {
               MessageBox.Show(someError.Message);
            }
        } 
    }
