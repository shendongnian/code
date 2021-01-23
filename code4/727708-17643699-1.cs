    [Export(typeof(IDatabase))]
    public class Database : IDatabase, IDisposable
    {
        [Import]
        public IDealerRepository Dealer { get; set; }
    
        // other code here...
    }
    
    [Export(typeof(IDealerRepository))]
    public class DealerRepository : IDealerRepository, IDisposable
    {
        [Import]
        private IEnvironmentSetting EnvironmentSetting { get; set; }
    
        // other code here...
    }
    [Export(typeof(IEnvironmentSetting))]
    public class EnvironmentSetting : IEnvironmentSetting, IDisposable
    {
        // other code here...
    }
