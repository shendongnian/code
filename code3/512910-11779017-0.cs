    public List <int> GetSortOrder(DataTable dt,string columnName)
    {
        List<int> Orders = new List<int>();
        int? nullableInt;
        foreach (DataRow row in dt.Rows)
        {
            nullableInt = (int)row[columnName];
            Orders.Add(nullableInt??0);
        }
        return Orders;
    }
