    SqlConnection conn2 = new SqlConnection();
    conn2.ConnectionString = ""; //your connection string
    SqlCommand scmd1 = new SqlCommand(QueryStr, conn2);
    scmd1.Parameters.Add("@Image", SqlDbType.VarBinary).Value = imgbytes;
    conn2.Open();
    scmd1.ExecuteNonQuery();
    conn2.Close();
