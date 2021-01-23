    SqlConnection sqlConnection1 = new SqlConnection("Your Connection String");
    SqlCommand cmd = new SqlCommand();
    SqlDataReader reader;
    cmd.CommandText = "select count(*) from topics";
    cmd.CommandType = CommandType.Text;
    cmd.Connection = sqlConnection;
    sqlConnection1.Open();
    reader = cmd.ExecuteReader();
    // Data is accessible through the DataReader object here.
    sqlConnection1.Close();
