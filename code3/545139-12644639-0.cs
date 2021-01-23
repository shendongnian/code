    public interface IRepository<T> where T:class, ILinqSqlObject
    {
        IQueryable<TSpec> GetAllDebts<TSpec>() where TSpec : T;
        IQueryable<TSpec> GetSpecificDebt<TSpec>(System.Linq.Expressions.Expression<Func<TSpec, bool>> predicate) where TSpec : T;
        void Insert<TSpec>(TSpec debt) where TSpec:T;
        // other methods
    }
    interface IDebtObject : ILinqSqlObject
    public interface IDebtManager:IRepository<IDebtObject> { }
    public class DebtManager:IDebtManager
    {
        DebtContext conn = new DebtContext();
        
        public DebtManager()
        {            
        }
        public void Insert<T>(T debt) where T:IDebtObject
        {
            throw new NotImplementedException();
        }
        public IQueryable<T> GetSpecificDebt(System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T:IDebtObject
        {
            return conn.GetTable<T>().Where(predicate);
        }
        public IQueryable<T> GetAllDebts<T>() where T:IDebtObject
        {
            return conn.GetTable<T>();
        }
    }
