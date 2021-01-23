    public class DbSetMock : IDbSet<Tenant>
    {
        
        TDerivedEntity IDbSet<Tenant>.Create<TDerivedEntity>()
        {
            throw new NotImplementedException();
        }
    }
