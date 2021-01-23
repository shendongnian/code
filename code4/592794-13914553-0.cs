    if (_mainConnection == null)
    {
      throw new Exception("_mainConnection is null");
    }
    SqlCommand cmd = new SqlCommand("something", _mainConnection);
    cmd.CommandType = CommandType.StoredProcedure;
    if (string.IsNullOrEmpty(SessionParam.ID))
    {
      throw new Exception("SessionParam.ID is null or empty");
    }
    cmd.Parameters.Add(new SqlParameter("ID", SessionManager.Session[SessionParam.ID].ToString()));
    if (type == null)
    {
      throw new Exception("type is null")
    }
    cmd.Parameters.Add(new SqlParameter("Type", type));
    var res =  _mainDb.ExecuteDataSet(cmd);
    if (res == null)
    {
      throw new Exception("res is null")
    }
    if ((res.Tables == null) || (res.Tables.Length == 0))
    {
      throw new Exception("tables is null or = 0")  
    }
    return res.Tables[0];
