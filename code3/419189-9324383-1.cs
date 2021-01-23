    if (dtTable.Rows[0][4] != null && dtTable.Rows[0][4] != DBNull.Value)
    {
        dblRevenue = Convert.ToDouble(dtTable.Rows[0][4]);
        ...
    }
    else
    {
        dblRevenue = 0.0;
    }
