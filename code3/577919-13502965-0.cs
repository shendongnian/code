    using System.Net;
    
    //Download
    WebClient Client = new WebClient ();
    Client.DownloadFile("http://ts1.travian.com/map.sql", @"C:\folder\file.sql");
    
    // Read into a file
    var sqltext = System.IO.File.ReadAllText(@"c:\folder\file.sql");
    // Split the sql statements up
    var sqlStatements = sqltext.Split(';'); 
    
    // Insert
    using (SqlConnection connection = new SqlConnection(connectionParameters))
        {   
            connection.Open();
            foreach (var sqlStatement in sqlStatements)  
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.ExecuteNonQuery();
            }
        }     
