    public interface IParameter {
        //... 
    }
    public abstract class DataRepository<T, TParameter>
        where TParameter : IParameter {
        public abstract IEnumerable<T> RetrieveAll(TParameter parameter1);
        public abstract bool Delete(TParameter parameter1);
    }
    public interface IAudit {/* ... */}
    public interface IAuditSearch : IParameter {/* ... */}
    
    public class SearchRepository : DataRepository<IAudit, IAuditSearch> {
        public override bool Delete(IAuditSearch parameter1) {
            // CODE GOES HERE
        }
        public override IEnumerable<IAudit> RetrieveAll(IAuditSearch parameter1) {
            // CODE GOES HERE
        }
    }
