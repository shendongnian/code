    string strConnStr = "My Connection String";
    SqlConnection sqlConn = new SqlConnection(strConnStr);
    SqlCommand sqlComm = new SqlCommand("SELECT * FROM Table1", sqlConn);
    sqlConn.Open();
    SqlDataReader reader = sqlComm.ExecuteReader();
    if (reader.HasRows)
    {
        while (reader.Read())
        {
            Console.WriteLine("Column 2: " + reader[2].ToString());
        }
    }
    reader.close()
               
