    DataSet dataSet = new DataSet();
    String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
    using (SqlConnection con = new SqlConnection(strConnString))
    {
       using (SqlCommand cmd = new SqlCommand("select distinct GroupName" +
                        " from MyTable"))
       {
           cmd.Connection = con;
   
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           da.Fill(dataSet);
    
           ddlGroupName1.DataSource = dataSet.Tables[0];
           ddlGroupName1.DataBind();
       }
    }
