    public interface IDinnerContext : IDisposable
    {
        IDbSet<Dinner> Dinners;
        int SaveChanges();
    }
