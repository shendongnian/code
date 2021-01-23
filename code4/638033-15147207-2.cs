    DbDataReader reader = comm.ExecuteReader();
    string stock = "0";
        
    while (reader.Read())
    {
		// get the results of each column
		stock = reader["stockprice"].ToString();
		break;
    }
    reader.Close();
    conn.Close();
    return Convert.ToDouble(stock);
