    public interface IParameter<T> {
        bool Match(T entry);
    }
    public abstract class DataRepository<T, TParameter>
        where TParameter : IParameter<T> {
        public abstract IEnumerable<T> RetrieveAll(TParameter parameter1);
        public abstract bool Delete(TParameter parameter1);
    }
    //
    public interface IAudit {/* ... */}
    public interface IAuditSearch : IParameter<IAudit> {/* ... */}
    public class SearchRepository : DataRepository<IAudit, IAuditSearch> {
        public override bool Delete(IAuditSearch parameter1) {
            // iterate by collection items using parameter matching
            // CODE GOES HERE (DELETE ALL FOUND ENTRIES)
        }
        public override IEnumerable<IAudit> RetrieveAll(IAuditSearch parameter1) {
            // iterate by collection items using parameter matching
            // CODE GOES HERE (RETURN ALL FOUND ENTRIES)
        }
    }
