    string str = null;
    StreamReader sr = new StreamReader(YourTextFilePath);
    using (var con = new SqlConnection(YourConnectionString))
    {
        while ( (str = sr.ReadLine()) != null)
        {
            cmd = new SqlCommand("Insert into table_name values ('" + str + "')", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }
    }
