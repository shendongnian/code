    // Code for bulk insert
    if (dtDetail.Rows.Count > 0)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlBulkCopy bulk = new SqlBulkCopy(connectionString);
        bulk.DestinationTableName = "t_ap_line_setup";
        bulk.WriteToServer(dtDetail);
    }
