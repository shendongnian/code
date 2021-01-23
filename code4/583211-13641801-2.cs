    public static class StatisticFactory 
    {
        public static void ImposeStatistics(IStatistics statsType)
        {
            statsType.ImposeStatistics();
        }
        /// <summary>
        /// Get the conversion type.
        /// </summary>
        /// <param name="col">The column to perform the conversion upon.</param>
        public static IStatistics GetStatsType(string typeName)
        {
            switch (typeName)
            {
                case "BoseEinstein":
                    return new BoseEinsteinStats();
                case "FermiDirac":
                    return new FermiDiracStats();
                default:
                    return null;
            }
        }
    }
    
