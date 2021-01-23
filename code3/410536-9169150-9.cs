    public class ODataServiceUpdateProvider<T> : IDataServiceUpdateProvider where T : IODataContext
    {
        private IDataServiceMetadataProvider _metadata;
        private ODataServiceQueryProvider<T> _query;
        private List<Action> _actions;
        public T GetContext()
        {
            return ((T)_query.CurrentDataSource);
        }
        public void SetConcurrencyValues(object resourceCookie, bool? checkForEquality, IEnumerable<KeyValuePair<string, object>> concurrencyValues)
        {
            throw new NotImplementedException();
        }
        public void SetReference(object targetResource, string propertyName, object propertyValue)
        {
            _actions.Add(() => ReallySetReference(targetResource, propertyName, propertyValue));
        }
        public void ReallySetReference(object targetResource, string propertyName, object propertyValue)
        {
            targetResource.SetPropertyValue(propertyName, propertyValue);
        }
        public void AddReferenceToCollection(object targetResource, string propertyName, object resourceToBeAdded)
        {
            _actions.Add(() => ReallyAddReferenceToCollection(targetResource, propertyName, resourceToBeAdded));
        }
        public void ReallyAddReferenceToCollection(object targetResource, string propertyName, object resourceToBeAdded)
        {
            var collection = targetResource.GetPropertyValue(propertyName);
            if (collection is IList)
            {
                (collection as IList).Add(resourceToBeAdded);
            }
        }
        public void RemoveReferenceFromCollection(object targetResource, string propertyName, object resourceToBeRemoved)
        {
            _actions.Add(() => ReallyRemoveReferenceFromCollection(targetResource, propertyName, resourceToBeRemoved));
        }
        public void ReallyRemoveReferenceFromCollection(object targetResource, string propertyName, object resourceToBeRemoved)
        {
            var collection = targetResource.GetPropertyValue(propertyName);
            if (collection is IList)
            {
                (collection as IList).Remove(resourceToBeRemoved);
            }
        }
        public void ClearChanges()
        {
            _actions.Clear();
        }
        public void SaveChanges()
        {
            foreach (var a in _actions)
                a();
            GetContext().SaveChanges();
        }
        public object CreateResource(string containerName, string fullTypeName)
        {
            ResourceType type = null;
            if (_metadata.TryResolveResourceType(fullTypeName, out type))
            {
                var context = GetContext();
                var resource = context.CreateResource(type);
                _actions.Add(() => context.AddResource(type, resource));
                return resource;
            }
            throw new Exception(string.Format("Type {0} not found", fullTypeName));
        }
        public void DeleteResource(object targetResource)
        {
            _actions.Add(() => GetContext().DeleteResource(targetResource));
        }
        public object GetResource(IQueryable query, string fullTypeName)
        {
            var enumerator = query.GetEnumerator();
            if (!enumerator.MoveNext())
                throw new Exception("Resource not found");
            var resource = enumerator.Current;
            if (enumerator.MoveNext())
                throw new Exception("Resource not uniquely identified");
            if (fullTypeName != null)
            {
                ResourceType type = null;
                if (!_metadata.TryResolveResourceType(fullTypeName, out type))
                    throw new Exception("ResourceType not found");
                if (!type.InstanceType.IsAssignableFrom(resource.GetType()))
                    throw new Exception("Unexpected resource type");
            }
            return resource;
       }
        public object ResetResource(object resource)
        {
            _actions.Add(() => ReallyResetResource(resource));
            return resource;
        }
        public void ReallyResetResource(object resource)
        {
            var clrType = resource.GetType();
            ResourceType resourceType = _metadata.Types.Single(t => t.InstanceType == clrType);
            var resetTemplate = GetContext().CreateResource(resourceType);
            foreach (var prop in resourceType.Properties
                     .Where(p => (p.Kind & ResourcePropertyKind.Key) != ResourcePropertyKind.Key))
            {
                var clrProp = clrType.GetProperties().Single(p => p.Name == prop.Name);
                var defaultPropValue = clrProp.GetGetMethod().Invoke(resetTemplate, new object[] { });
                clrProp.GetSetMethod().Invoke(resource, new object[] { defaultPropValue });
            }
        }
	
        public object ResolveResource(object resource)
        {
            return resource;
        }
        public object GetValue(object targetResource, string propertyName)
        {
            var value = targetResource.GetType().GetProperties().Single(p => p.Name == propertyName).GetGetMethod().Invoke(targetResource, new object[] { });
            return value;
        }
        public void SetValue(object targetResource, string propertyName, object propertyValue)
        {
            targetResource.GetType().GetProperties().Single(p => p.Name == propertyName).GetSetMethod().Invoke(targetResource, new[] { propertyValue });
         }
         public ODataServiceUpdateProvider(IDataServiceMetadataProvider metadata, ODataServiceQueryProvider<T> query)
         {
             _metadata = metadata;
             _query = query;
             _actions = new List<Action>();
        }
    }
