    try
    {
        sqlCon = new SqlConnection(connectionString);
        sqlCmd = new SqlCommand();
        sqlCmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter daAC_CSM = new SqlDataAdapter();
        DataSet dsAC_CSM = new DataSet();
        sqlCmd.Connection = sqlCon;
        sqlCmd.CommandTimeout = 0;
        sqlCmd.CommandText = "DFW_Completed_Safety";
        sqlCmd.Parameters.AddWithValue("@StartDate", startdate);  //Using "@"
        sqlCmd.Parameters.AddWithValue("@Station", station);    //Using "@"
        sqlCmd.Parameters.AddWithValue("@EmployeeID", 0); //Using "@"
        foreach(SqlParameter p in  sqlCmd.Parameters){
          //Will print Name, Type and Value
          System.Diagnostics.Trace.WriteLine("Name:" + p.ParameterName + "Type: " + p.DbType+" Value: "+p.Value); 
        }
        sqlCon.Open();
        daAC_CSM.SelectCommand = sqlCmd;
        daAC_CSM.Fill(dsAC_CSM);
        sqlCon.Close();
        return dsAC_CSM;
    }
    catch (Exception ex)
    {
        throw ex;
    }
