    async public Task<GameStatistic> GetReportData()
    {
        var repo = new GameRepository();
        return await repo.LoadReport(); //(awaitable) Task<GameStatistic>
    }
