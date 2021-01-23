    public void UpdateDailyCustomerWithLCDHistory(string callerId, int callLogId, string csrName)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase("MarketingWriteConnectionString");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CSR_UpdateDailyCustomerWithLCDHistory");
            dbCommand.CommandTimeout = AppSetting.Instance.GetCommandTimeout();
            db.AddInParameter(dbCommand, "person_id", DbType.Decimal, callerId);
