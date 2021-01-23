    SqlDataReader rdr = null;
    SqlConnection con = null;
    SqlCommand cmd = null;
    List<string> empName=new List<string>();
    
                try
                {
                    // Open connection to the database
                    string ConnectionString = "server=yourservername;uid=sa;"+
                        "pwd=yourpswd; database=yourdatabase";
                    con = new SqlConnection(ConnectionString);
                    con.Open();
    
                    // Set up a command with the given query and associate
                    // this with the current connection.
                    string CommandText = "SELECT FirstName" +
                                         "  FROM Employees" +
                                         " WHERE (FirstName LIKE +name%)";
                    cmd = new SqlCommand(CommandText);
                    cmd.Connection = con;
    
                   
                    // Execute the query
                    rdr = cmd.ExecuteReader();
    
                   
                    while(rdr.Read())
                    {
                       empName.Add(rdr["FirstName"].ToString());
                    }
                  return empName;
                }
                catch(Exception ex)
                {
                    // Print error message
                   
                }
