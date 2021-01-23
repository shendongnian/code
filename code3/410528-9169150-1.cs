    public class ODataServiceMetadataProvider : IDataServiceMetadataProvider
    {
        private Dictionary<string, ResourceType> resourceTypes = new Dictionary<string, ResourceType>();
        private Dictionary<string, ResourceSet> resourceSets = new Dictionary<string, ResourceSet>();
        private List<ResourceAssociationSet> _associationSets = new List<ResourceAssociationSet>(); 
        public string ContainerName
        {
            get { return "MyDataContext"; }
        }
         public string ContainerNamespace
         {
             get { return "MyNamespace"; }
         }
        public IEnumerable<ResourceSet> ResourceSets
        {
             get { return this.resourceSets.Values; }
        }
        public IEnumerable<ServiceOperation> ServiceOperations
        {
            get { yield break; }
        }
        public IEnumerable<ResourceType> Types
        {
            get { return this.resourceTypes.Values; }
        }
        public bool TryResolveResourceSet(string name, out ResourceSet resourceSet)
        {
            return resourceSets.TryGetValue(name, out resourceSet);
        }
        public bool TryResolveResourceType(string name, out ResourceType resourceType)
        {
            return resourceTypes.TryGetValue(name, out resourceType);
        }
        public bool TryResolveServiceOperation(string name, out ServiceOperation serviceOperation)
        {
            serviceOperation = null;
            return false;
        }
        public void AddResourceType(ResourceType type)
        {
            type.SetReadOnly();
            resourceTypes.Add(type.FullName, type);
        }
        public void AddResourceSet(ResourceSet set)
        {
            set.SetReadOnly();
            resourceSets.Add(set.Name, set);
        }
        public bool HasDerivedTypes(ResourceType resourceType)
        {
            if (resourceType.InstanceType == typeof(ResidentialCustomer))
            {
                return true;
            }
            return false;
        }
        public IEnumerable<ResourceType> GetDerivedTypes(ResourceType resourceType)
        {
            List<ResourceType> derivedResourceTypes = new List<ResourceType>();
            if (resourceType.InstanceType == typeof(ResidentialCustomer))
            {
                foreach (ResourceType resource in Types)
                {
                    if (resource.InstanceType == typeof(Customer))
                    {
                        derivedResourceTypes.Add(resource);
                    }
                }
            }
            return derivedResourceTypes;
        }
        public void AddAssociationSet(ResourceAssociationSet associationSet) 
        {
            _associationSets.Add(associationSet); 
        }
        public ResourceAssociationSet GetResourceAssociationSet(ResourceSet resourceSet, ResourceType resourceType, ResourceProperty resourceProperty)
        {
            return resourceProperty.CustomState as ResourceAssociationSet;
        }
        public ODataServiceMetadataProvider() { }
    }
