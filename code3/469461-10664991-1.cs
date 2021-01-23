    List<ParamData> list = new List<ParamData>();
    //initialize command here as u did
    SqlCommand cmd;
    foreach (ParamData param in list)
    {
      SqlParameter sqlParam = new SqlParameter(param.ParamName, param.type);
      sqlParam.Value = param.Data;
      cmd.Parameters.Add(sqlParam);
    }
    //execute the command
    //fill the datatable with result
    DataTable dt = GetTableBySPName("GetDays");
    SqlDataReader reader = cmd.ExecuteReader();
    dt.Load(reader);
