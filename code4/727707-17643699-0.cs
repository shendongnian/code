    public interface IEnvironmentSetting
    {
        string Emulation { get; }
        string Application { get; }
        string Database { get; }
    }
    
    public interface IDealerRepository
    {
        string EnvironmentResponse();
        string DealerProifle_Lookup(string parmName);
        string DealerProfile_Save(string parmName)
    }
    public interface IDatabase
    {
        IDealerRepository Dealer { get; }
    }
