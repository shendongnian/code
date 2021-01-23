    public interface IDataFieldDependencyService
    {
        IList<INode> GetAllFieldDependencies();
    }
    public class FieldDependencyDataService : BaseDataService, IFieldDependencyService
    {
        public FieldDependencyDataService(DataAccessHandle serviceHandler) : base(serviceHandler) {}
        public IList<INode> GetAllFieldDependencies()
        {
            return _accessService.loadAll<FieldDependency>();
        }
    }
