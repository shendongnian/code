    [WebMethod]
    public List<GlobalStat> GetStats()
    {
        GlobalStatsRepository repository = new GlobalStatsRepository();
        List<GlobalStat> stats = repository.GetStats();
        return stats;
    }
