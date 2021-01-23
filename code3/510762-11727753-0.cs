    private void LoadReport() 
    { 
        SqlConnection con = new SqlConnection(GetConnectionString()); 
        try 
        { 
            con.Open(); 
            SqlDataAdapter da = new SqlDataAdapter("your select query", con); 
            DataSet myds = new DataSet(); 
            da.Fill(myds); 
            yourreportname.SetDataSource(myds.Tables[0]); 
            crystalReportViewer1.ReportSource = yourreportname; 
        } 
        catch 
        { throw new Exception("Failed to load report"); } 
        finally 
        { if (con.State == ConnectionState.Open) con.Close(); con.Dispose(); } 
    } 
    private string GetConnectionString() 
    { 
        return ConfigurationManager.ConnectionStrings["your connectionstring name"].ConnectionString; 
    }
