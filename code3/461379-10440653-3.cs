     DataSet ds = new DataSet();
     for (int i = 0; i < dt.Rows.Count; i++)
         {
             row = dt.Rows[i];
            db.getComboxedCombinedRSS( row[0].ToString(), ds);
         }
         GridView1.DataSource = ds;
         GridView1.DataBind();
    
    
    
    
    public void getComboxedCombinedRSS(string url, DataSet ds)
    {
        //SQL string to count the amount of rows within the OSDE_Users table
        //string sql = "SELECT [RSS_Title], [RSS_ID], R.Syndication, R.Category FROM RSS AS R INNER JOIN CombinedFeeds AS C ON  C.URL = R.URL  WHERE C.Name='" +name+" ' ORDER BY RSS_Date desc";
        string sql="SELECT top 30 [RSS_Title], [RSS_ID], Syndication, Category FROM RSS where URL= '"+url+"' order by RSS_DATE";
        SqlDataAdapter adapt = new SqlDataAdapter(sql, Connect());
        
        adapt.Fill(ds);
    
        // result of query filled into datasource
        adapt.Dispose();
    
        closeConnection();
        return ds;
    }
