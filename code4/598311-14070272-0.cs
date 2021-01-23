    String Connectionstring = CCMMUtility.CreateConnectionString(false, txt_DbDataSource.Text, "master", "sa", "happytimes", 1000);
    
    using(SqlConnection con = new SqlConnection(Connectionstring)) {
        con.Open();
        String sqlCommandText = @"
            ALTER DATABASE " + DbName + @" SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
            DROP DATABASE [" + DbName + "]";
        SqlCommand sqlCommand = new SqlCommand(sqlCommandText, con);
        sqlCommand.ExecuteNonQuery();
    }
    result = 1;
