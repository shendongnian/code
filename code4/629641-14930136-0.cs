    try
    {
      strQry = @"Update UserMaster set Password=?, RoleID=? where UserID=?";
      var p1 = command.CreateParameter();
      p1.Value = strUserPwd;
      command.Parameters.Add(p1);
    
      var p2 = command.CreateParameter();
      p2.Value = intRoleID;
      command.Parameters.Add(p2);
    
      var p3 = command.CreateParameter();
      p3.Value = intUserID;
      command.Parameters.Add(p3);
    
      cmd.Connection = con;
      cmd.CommandText = strQry;
      con.Open();
      intReturn = cmd.ExecuteNonQuery();
      con.Close();
    }
    catch(Exception ex)
    {
        throw new Exception(ex.Message);
    }
