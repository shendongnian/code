    public class DerivedDialectWithNewId : MsSql2005Dialect
    {
        public DerivedDialectWithNewId()
        {
            RegisterFunction("newid", new NoArgSQLFunction("newid", NHibernateUtil.Guid, true));        
        }
    }
