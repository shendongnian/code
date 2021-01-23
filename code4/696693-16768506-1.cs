    using (SqlDataAdapter da = new SqlDataAdapter())
    {
        da.SelectCommand.CommandText = "you sql command";
        da.SelectCommand.Connection = new SqlConnection("your connection");
    
        string xml = "";
        using (DataSet ds = new DataSet())
        {
            da.SelectCommand.Connection.Open();
            da.Fill(ds);
            da.SelectCommand.Connection.Close();
            if(ds != null && ds.Tables.Count > 0)    
               xml = ds.GetXml();
        }
    }
