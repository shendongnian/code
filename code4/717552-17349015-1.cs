    SqlDataAdapter da = new SqlDataAdapter();
    //updated to explicitly create update command object
    SqlCommand update = new SqlCommand("spInvent",cs);
    update.CommandType = System.Data.CommandType.StoredProcedure;
    update.Parameters.AddWithValue("@DisplayNo", displayNo);
    update.Parameters.AddWithValue("@Q", Q);
    da.UpdateCommand = update;
    //don't need this line:
    //da.UpdateCommand.ExecuteNonQuery();
    
    DataSet ds = new DataSet();
    
    da.Fill(ds);
    gvInfo.DataSource = ds;
    gvInfo.DataBind();
