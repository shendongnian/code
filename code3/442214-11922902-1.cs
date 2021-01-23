    public class TeamCityOrNCrunchReporter : FirstWorkingReporter
    {
        public static readonly TeamCityOrNCrunchReporter INSTANCE = 
            new TeamCityOrNCrunchReporter();
        public TeamCityOrNCrunchReporter()
            : base(NCrunchReporter.INSTANCE,
            TeamCityReporter.INSTANCE) { }
    }
    [assembly: FrontLoadedReporter(typeof(TeamCityOrNCrunchReporter))]
