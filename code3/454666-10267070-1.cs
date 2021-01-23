    public DataTable FilterDataTableByDates(DataTable td, DateTime from, DateTime to)
    {
        DataTable tempTd = td.Clone();
        foreach (DataRow dr in td.Rows)
        {
            long ticks = Convert.ToInt64(dr["cpd_date"].ToString());
            if (ticks > from.Ticks && ticks < to.Ticks)
            {
                tempTd.ImportRow(dr);
            }
        }
        return tempTd.Copy();
    }
