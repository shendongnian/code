    // for instance
    List<string> list = new List<string>();
    
    if (sqlReader != null)
        {
            if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {
                    //return sqlReader[0].ToString();
                    list.Add(sqlReader[0].ToString());
                }
                sqlConn.Close();
            }
            else
            {
                return null;
            }
        }
    return list; // ta-da
