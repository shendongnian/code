    async public Task<MyResultClass> GetReportAndResult()
    {
         var gameStat = await GetReportData();
         return ReportDataToMyResult(gameStat);
    }
