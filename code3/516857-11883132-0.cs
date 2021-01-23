    string sqlStmt = "SELECT Timein, Timeout FROM dbo.Attendance " + 
                     "WHERE E_ID = @ID AND Date = @Date";
    using(SqlConnection conn = new SqlConnection("your-connection-string-here"))
    using(SqlCommand cmd = new SqlCommand(sqlStmt, conn))
    {
        // set up parameters
        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = E_ID;
        cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = DateTime.Now.Date;
        // open connection, read data, close connection
        conn.Open();
        using(SqlDataReader rdr = cmd.ExecuteReader())
        {
           while(rdr.Read())
           {
              // read your data
           }
           rdr.Close();
        }
        conn.Close();
    }
