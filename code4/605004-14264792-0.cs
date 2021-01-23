    public List<CumulativeInstrumentsDataRow> GetCumulativeInstrumentLogs(RunLogFilter filter)
        {
            EFDbContext db = new EFDbContext();
            if (filter.SystemFullName == string.Empty)
            {
                filter.SystemFullName = null;
            }
            if (filter.Reconciled == null)
            {
                filter.Reconciled = 1;
            }
            string sql = GetRunLogFilterSQLString("[dbo].[rm_sp_GetCumulativeInstrumentLogs]", filter);
            return db.Database.SqlQuery<CumulativeInstrumentsDataRow>(sql).ToList();
        }
