    string query = "AddCategory";
    int ID;
    string connect = @"Server=.\SQLExpress;Database=Northwind;Trusted_Connection=Yes;";
    using (SqlConnection conn = new SqlConnection(connect))
    {
      using (SqlCommand cmd = new SqlCommand(query, conn))
      {
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Category", Category.Text);
        cmd.Parameters.Add("@CategoryID", SqlDbType.Int, 0, "CategoryID");
        cmd.Parameters["@CategoryID"].Direction = ParameterDirection.Output;
        conn.Open();
        cmd.ExecuteNonQuery();
        ID = (int)cmd.Parameters["@CategoryID"].Value;
      }
    }
