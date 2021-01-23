    SqlCommand cmd = new SqlCommand();
    
    cmd.Parameters.Add(new SqlParameter("@StartDate", startDate)); 
    cmd.Parameters.Add(new SqlParameter("@EndDate", endDate)); 
    
    var thisConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString; 
    
    SqlConnection thisConnection = new SqlConnection(thisConnectionString); 
    
    cmd.Connection = thisConnection; 
    
    cmd.CommandText = string.Format("[dbo].[StoredProcedureName]"); 
    cmd.CommandType = CommandType.StoredProcedure; 
    SqlDataAdapter da = new SqlDataAdapter(cmd); 
    
    System.Data.DataSet thisDataSet = new System.Data.DataSet(); 
    
    da.Fill(thisDataSet); 
    
    ////////////
    /// HERE ///
    ////////////
    ReportDataSource datasource = new ReportDataSource(rptName, thisDataSet.Tables[0]); 
    
    ReportViewer1.LocalReport.DataSources.Clear(); 
    ReportViewer1.LocalReport.DataSources.Add(datasource); 
    
    ....................
    
    ReportViewer1.LocalReport.Refresh();
