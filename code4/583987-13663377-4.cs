     //Declare the connection object
        SqlConnection Conn = new SqlConnection();
        Conn.ConnectionString = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
        //Connect to the db
        Conn.Open();
        //Define query
        //This query doesn't work
        string sql = "SELECT CustomerID, LastName, FirstName, Email, Password, Address1, Address2, City, State, Zip, Phone, Fax FROM Customer WHERE (State LIKE '%" + txtSearch.Text + "%')";
      //Declare a SQL Adapter
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
