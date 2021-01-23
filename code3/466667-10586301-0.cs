    //Build the connection 
    SqlConnectionStringBuilder bldr = new SqlConnectionStringBuilder();
    
    //Put your server or server\instance name here.  Likely YourComputerName\SQLExpress
    bldr.DataSource = ".\\SQLEXPRESS";
    
    //Attach DB Filename
    bldr.AttachDBFilename = bldr.AttachDBFilename = @"C:\USERS\CEM\DOCUMENTS\VISUAL STUDIO 2010\WEBSITES\EKLEMEDENE\APP_DATA\DATABASE.MDF";
    
    //User Instance
    bldr.UserInstance = true;
    
    //Whether or not a password is required.
    bldr.IntegratedSecurity = true;
    
    using(var connection = new SqlConnection(bldr.ConnectionString))
    {
        var sql = "INSERT INTO ekle(flight, name, food) VALUES (@flight, @name , @food)";
        using(var command = new SqlCommand(sql, con))
        {
            command.Parameters.AddWithValue("@flight", TextBox1.Text);
            command.Parameters.AddWithValue("@name", TextBox2.Text);
            command.Parameters.AddWithValue("@food", DropDownList1.SelectedValue); 
            connection.Open();
            command.ExecuteNonQuery();
        }
    } // closes the connection implicitely
