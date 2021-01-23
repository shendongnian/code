    // Create an abstract class to be used as the base for classes that are supported by
    // ExistsCommand and any other classes where you need a similar pattern
    public abstract class ExtendedCriteria<T> : IGeneratedCriteria
    {
        public ExistsCommand GetExistsCommand()
        {
            return new ExistsCommand<T>(this);
        }
    }
    // Make the non-generic ExistsCommand abstract
    public abstract class ExistsCommand
    {
        protected abstract void DataPortal_Execute();
    }
    // Create a generic sub-class of ExistsCommand with the type parameter used in the GetTable call
    // where you were previously trying to use the EntityType property
    public class ExistsCommand<T> : ExistsCommand
    {
        protected override void DataPortal_Execute()
        {
            using (var ctx = new DC.ADRPDataContext())
            {
                Result = ctx.GetTable<T>().Where(LinqToSQLHelper.BuildWhereStatement(Criteria.StateBag), Criteria.StateBag.Values.ToArray()).Count() > 0;
            }
        }
    }
    // Derive the AccountCriteria from ExtendedCriteria<T> with T the entity type
    public class AccountCriteria : ExtendedCriteria<DAL.Account>
    {
        ...
    }
