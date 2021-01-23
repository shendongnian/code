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
    
    if (result > 0)
               {
                   //Your Database is updated. To show it in gridview, you have
                   //to select the table and show its data.
                   SqlCommand cmd1 = new SqlCommand();
                   cmd1.Connection = cs;
                   cmd1.CommandText = "SelectStoredProcedureName";
                   cmd1.CommandType = CommandType.StoredProcedure;
                   cmd1.Parameters.AddWithValue("@displayId", 0); 
                   //In the SelectStoredProcedure, use @displayId = 0 to 
                   //show all rows.
                   SqlDataAdapter adpt = new SqlDataAdapter();
                   adpt.SelectCommand = cmd1;
                   DataSet ds = new DataSet();
                   adpt.Fill(ds);
                   con.Close();
                   GridViewID.DataSource = ds;
                   GridViewId.DataBind();
                }
    else
    {
        con.Close();
    }
