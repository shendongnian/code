     //Declare the connection object
        SqlConnection Conn = new SqlConnection();
        Conn.ConnectionString = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
        //Connect to the db
        Conn.Open();
        //Define query
        //This query doesn't work
        string sql = "SELECT CustomerID, LastName, FirstName, Email, Password, Address1, Address2, City, State, Zip, Phone, Fax FROM Customer WHERE (State LIKE @Search)";
        //Declare the Command
        SqlCommand cmd = new SqlCommand(sql, Conn);
        //Add the parameters needed for the SQL query
        cmd.Parameters.AddWithValue("@Search", "%" + txtSearch.Text + "%"); 
      //Declare a SQL Adapter
        SqlDataAdapter da = new SqlDataAdapter();
            cmd.connection = conn
            sa.SelectCommand = cmd
