    public class DbSetMock : IDbSet<Tenant>
        {
            /* hidden all other implemented methods/properties */
    
            public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : Tenant
            {
                throw new NotImplementedException();
            }
        }
