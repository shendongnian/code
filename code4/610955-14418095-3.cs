    public class DbSetMock : IDbSet<Tenant>
    {
        TDerivedEntity IDbSet<Tenant>.Create<TDerivedEntity>()
        {
            return Create<TDerivedEntity>();
        }
        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : Tenant
        {
            throw new NotImplementedException();
        }
    }
