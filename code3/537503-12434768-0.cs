    using(SqlConnection connection = new SqlConnection(connString.ToString())){
    string insert = "Insert Query";
    using (SqlCommand sqlCommand = new SqlCommand(insert,connection))
    {
     con.Open();
     int i = sqlCommand.ExecuteNonQuery();
    }
    }
