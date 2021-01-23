    private async Task DatabaseTestAsync()
    {
        ...
        if (db.selectDashboard(callC).Count == 0)
        {
            await GetDataSummaryAsync(passC);
        }
        if (db.selectDashboard(callB).Count == 0)
        {
            await GetDataSummaryAsync(passB);
        }
        if (db.selectDashboard(callF).Count == 0)
        {
            await GetDataSummaryAsync(passF);
        }
    }
    private async Task GetDataSummaryAsync(string r)
