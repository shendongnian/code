    public class ODataServiceQueryProvider<T> : IDataServiceQueryProvider where T : IODataContext
    {
        T _currentDataSource;
        IDataServiceMetadataProvider _metadata;
        public object CurrentDataSource
        {
            get
            {
                return _currentDataSource;
            }
            set
            {
                _currentDataSource = (T)value;
            }
        }
        public bool IsNullPropagationRequired
        {
            get { return true; }
        }
        public object GetOpenPropertyValue(object target, string propertyName)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<KeyValuePair<string, object>> GetOpenPropertyValues(object target)
        {
            throw new NotImplementedException();
        }
        public object GetPropertyValue(object target, ResourceProperty resourceProperty)
        {
            throw new NotImplementedException();
        }
        public IQueryable GetQueryRootForResourceSet(ResourceSet resourceSet)
        {
            return _currentDataSource.GetQueryable(resourceSet);
        }
        public ResourceType GetResourceType(object target)
        {
            Type type = target.GetType();
            return _metadata.Types.Single(t => t.InstanceType == type);
        }
        public object InvokeServiceOperation(ServiceOperation serviceOperation, object[] parameters)
        {
            throw new NotImplementedException();
        }
        public ODataServiceQueryProvider(IDataServiceMetadataProvider metadata)
        {
            _metadata = metadata;
        }
    }
