    string numList = string.Join(",", numbers.Select(i=>i.ToString()).ToList());
    // you need to have connection initialized with connection string
    SqlDataAdapter a = new SqlDataAdapter("select value from table where id in (" + numList + ")", connection);
    DataTable dt = new DataTable();// the result goes here
    a.Fill(dt);// actually querying the database
