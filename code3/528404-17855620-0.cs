    //if the database has already password
    try{
                string conn = @"Data Source=database.s3db;Password=Mypass;";
                SQLiteConnection connection= new SQLiteConnection(conn);
                connection.Open();
                //Some code
                connection.ChangePassword("Mypass");
                connection.Close();
        }
    //if it is the first time sets the password in the database
    catch
        {
                string conn = @"Data Source=database.s3db;";
                SQLiteConnection connection= new SQLiteConnection(conn);
                connection.Open();
                //Some code
                connection.ChangePassword("Mypass");
                connection.Close();
        }
