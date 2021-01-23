    public class TeamCityReporter : IEnvironmentAwareReporter, IApprovalFailureReporter
    {
        public static readonly TeamCityReporter INSTANCE = new TeamCityReporter();
        public void Report(string approved, string received) { }
        public bool IsWorkingInThisEnvironment(string forFile)
        {
            return Environment.GetEnvironmentVariable("TEAMCITY_PROJECT_NAME") != null;
        }
    }
