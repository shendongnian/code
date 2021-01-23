    public interface ILeagueRepository 
    {
        IEnumerable<League> All;
    }
    public interface ILeaguesProvider
    {
        IEnumerable<League> GetUserLeagues(string Username);
    }
    public class LeaguesProvider : ILeaguesProvider
    {
        public LeaguesProvider(ILeagueRepository repository)
        {
             // ...
        }
        public IEnumerable<League> GetUserLeages(string Username)
        {
            return _repository.All.Where(league=>league.User == Username);
        }
    }
    public ActionResult LeaguesController
    {
        public LeaguesController(ILeaguesProvider providerDependency, IRoleProvider roleDependency)
        {
            IEnumerable<League> leagues = providerDependency.GetUserLeagues(roleDependency.GetCurrentUser());
        }
    }
