    ...
    oleConn.Open();
    string sql = "UPDATE [User] SET [emailAddress]=?, [password]=? WHERE [ID]=?";
    OleDbCommand oleComm = new OleDbCommand(sql, oleConn);
    oleComm.Parameters.Add("@emailAddress", OleDbType.Char).Value = emailAddress;
    oleComm.Parameters.Add("@password", OleDbType.Char).Value = password;
    oleComm.Parameters.Add("@user", OleDbType.Integer).Value = user;
    ...
