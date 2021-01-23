    SqlDataAdapter da = new SqlDataAdapter("spInvent",cs);
    da.UpdateCommand.CommandType = System.Data.CommandType.StoredProcedure;
    da.UpdateCommand.Parameters.AddWithValue("@DisplayNo", displayNo);
    da.UpdateCommand.Parameters.AddWithValue("@Q", Q);
    //don't need this line:
    //da.UpdateCommand.ExecuteNonQuery();
    
    DataSet ds = new DataSet();
    
    da.Fill(ds);
    gvInfo.DataSource = ds;
    gvInfo.DataBind();
