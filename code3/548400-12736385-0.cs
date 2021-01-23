    public interface IMyEntitiesContext : IDisposable
    {
        IDbSet<Profile> Profiles { get; }
        ...
        ...
        int SaveChanges();
    }
