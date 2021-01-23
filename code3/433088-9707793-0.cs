    public class SearchRepository : DataRepository<IAudit, IAuditSearch>
    {
        public override IEnumerable<IAudit> RetrieveAll<IAuditSearch>(IAuditSearch searchParameters)
        {
            // CODE GOES HERE
        }
        public override bool Delete<TIAudit>(IAudit audit)
        {
            // CODE GOES HERE
        }
    }
    public abstract class DataRepository<T, TSearch>
    {
        public virtual IEnumerable<T> RetrieveAll(TSearch parameter1)
        {
            throw new NotImplementedException();
        }
        public virtual bool Delete(T parameter1)
        {
            throw new NotImplementedException();
        }
    }
