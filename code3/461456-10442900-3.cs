    string sqlStmt = "dbo.StoreXmlData";  // name of your stored procedure
    // here, you need to use *YOUR* connection string instead of my demo one...    
    using(SqlConnection conn = new SqlConnection("server=.;database=test;integrated security=SSPI;"))
    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
    {
        // make sure to tell ADO.NET you're about to call a stored procedure!
        cmd.CommandType = CommandType.StoredProcedure;
        // define the parameter and set its value
        cmd.Parameters.Add("@YourData", SqlDbType.Xml);
        cmd.Parameters["@YourData"].Value = doc.DocumentElement.InnerXml;
        // standard ADO.NET - open connection, execute query, close connection
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }
