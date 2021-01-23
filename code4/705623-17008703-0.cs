    public DataTable CustomerTable()
    {
        using(SqlConnection cn = new SqlConnection(DataBaseHelper.DbConnectionString))
        ......
    }
