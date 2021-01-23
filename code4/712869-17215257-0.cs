    public static  string getAllExceptNiServiceNames()
    {
        string sql = "";
        DataSet ds = getServiceNames();
        int i = 0;
        foreach (DataRow theRow in ds.Tables[0].Rows)
        {   
            if (i != 0)
                sql += "AND ";
    
            sql += "serviceName = '" + theRow["serviceName"].ToString() + "' ";
    
            i++;
        }
        return sql;
    }
