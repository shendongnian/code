    private void BindData()
    {
        // if null then fetch from the database
        if (Cache["CoverageDataTable"] == null)
        {
            // Create the cache dependency
            SqlCacheDependency dep = new SqlCacheDependency("Coverage", CoverageDataTable");
            string connectionString = ConfigurationManager.ConnectionStrings[
                                            "ConnectionString"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionString);
            SqlDataAdapter ad = new SqlDataAdapter("SELECT ColA, ColB, ColC " +
                                                   "FROM CoverageDataTable", myConnection);
            DataSet ds = new DataSet();
            ad.Fill(ds);
    
            // put in the cache object
            Cache.Insert("CoverageDataTable", ds, dep);
        }
    
        gvCoverageDataTable.DataSource = Cache["CoverageDataTable"] as DataSet;
        gvCoverageDataTable.DataBind();
    }
