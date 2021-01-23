    OleDbConnection cn = new OleDbConnection(aconnectionstring);
    cn.Open();
    
    //testing
    int correctUser = 1;
    string userName = "1";
    OleDbCommand com = new OleDbCommand();
    com.Connection = cn;
    //You cannot have a parameter in DLookUp
    com.CommandText = "UPDATE [ExamMaster] SET [User] = " +
       "DLookup('LName', 'Users', 'ID = " + correctUser + "') WHERE [User] = @user";
    com.Parameters.AddWithValue("@user", userName);
    //You must execute the query
    com.ExecuteNonQuery();
