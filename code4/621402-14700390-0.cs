    string myExecutequery = "INSERT INTO Accountstbl (Username,Password) VALUES 
    (@user,@pass)";
    con.Open();
    try
    {
     OleDbCommand cmd = new OleDbCommand(sqlIns, con);
     cmd.Parameters.Add("@user", user);
     cmd.Parameters.Add("@pass", pass);     
     cmd.ExecuteNonQuery();
     cmd.Dispose();
     cmd = null;
    }
    catch(Exception ex)
    {
      throw new Exception(ex.ToString(), ex);
    }
    finally
    {
     con.Close();
    }
