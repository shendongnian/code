    using System.Data; 
    using System.Data.Sql; 
    using System.Data.SqlClient;
    using System.Configuration;
    
    SqlConnection cs = new
        SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);
      if (cs.State == ConnectionState.Closed)        
      {          
       cs.Open();        
      }
    SqlCommand cmd = new SqlCommand(); 
    cmd.Connection = cs; 
    cmd.CommandText = "UpdateStoredProcedureName"; 
    cmd.CommandType = CommandType.StoredProcedure; 
    cmd.Parameters.AddWithValue("@DisplayNo",displayNo); 
    cmd.Parameters.AddWithValue("@Q", Q); 
    int result = cmd.ExecuteNonQuery();
    SqlDataAdapter adpt = new SqlDataAdapter();
    adpt.SelectCommand = cmd;
    DataSet ds = new DataSet();
    adpt.Fill(ds);
    cs.Close(); 
    
    if (result > 0)
               {
                   //Your Database is updated. To show it in gridview, use Dataset.
                   GridviewID.DataSource = ds;
                   GridViewId.DataBind();
               }
