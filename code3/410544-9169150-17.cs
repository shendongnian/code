    public class ODataService<T> : DataService<T>, IServiceProvider where T : IODataContext
    {
        private ODataServiceMetadataProvider _metadata;
        private ODataServiceQueryProvider<T> _query;
        private ODataServiceUpdateProvider<T> _updater;
        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(IDataServiceMetadataProvider))
            {
                return _metadata;
            }
            else if (serviceType == typeof(IDataServiceQueryProvider))
            {
                return _query;
            }
            else if (serviceType == typeof(IDataServiceUpdateProvider))
            {
                return _updater;
            }
            else
            {
                return null;
            }
        }
        public ODataServiceMetadataProvider GetMetadataProvider(Type dataSourceType)
        {
            ODataServiceMetadataProvider metadata = new ODataServiceMetadataProvider();
            ResourceType customer = new ResourceType(
                typeof(Customer),
                ResourceTypeKind.EntityType,
                null,
                "MyNamespace",
                "Customer",
                false
            );
            ResourceProperty customerCustomerID = new ResourceProperty(
                "CustomerID",
                ResourcePropertyKind.Key |
                ResourcePropertyKind.Primitive,
                ResourceType.GetPrimitiveResourceType(typeof(Guid))
            );
            customer.AddProperty(customerCustomerID);
            ResourceProperty customerCustomerName = new ResourceProperty(
                "CustomerName",
                ResourcePropertyKind.Primitive,
                ResourceType.GetPrimitiveResourceType(typeof(string))
            );
            customer.AddProperty(customerCustomerName);
            ResourceType residentialCustomer = new ResourceType(
                typeof(ResidentialCustomer),
                ResourceTypeKind.EntityType,
                customer,
                "MyNamespace",
                "ResidentialCustomer",
                false
            );
            ResourceType user = new ResourceType(
                typeof(User),
                ResourceTypeKind.EntityType,
                null,
                "MyNamespace",
                "User",
                false
            );
            ResourceProperty userUserID = new ResourceProperty(
                "UserID",
                ResourcePropertyKind.Key |
                ResourcePropertyKind.Primitive,
                ResourceType.GetPrimitiveResourceType(typeof(Guid))
            );
            user.AddProperty(userUserID);
            ResourceProperty userCustomerID = new ResourceProperty(
                "CustomerID",
                ResourcePropertyKind.Primitive,
                ResourceType.GetPrimitiveResourceType(typeof(Guid))
            );
            user.AddProperty(userCustomerID);
            ResourceProperty userEmailAddress = new ResourceProperty(
                "EmailAddress",
                ResourcePropertyKind.Primitive,
                ResourceType.GetPrimitiveResourceType(typeof(string))
            );
            user.AddProperty(userEmailAddress);
            var customerSet = new ResourceSet("Customers", customer);
            var residentialCustomerSet = new ResourceSet("ResidentialCustomers", residentialCustomer);
            var userSet = new ResourceSet("Users", user);
            var userCustomer = new ResourceProperty(
                "Customer",
                ResourcePropertyKind.ResourceReference,
                customer
            );
            user.AddProperty(userCustomer);
			
            var customerUserList = new ResourceProperty(
                "UserList",
                ResourcePropertyKind.ResourceSetReference,
                user
            );
            customer.AddProperty(customerUserList);
			
            metadata.AddResourceType(customer);
            metadata.AddResourceSet(customerSet);
            metadata.AddResourceType(residentialCustomer);
            metadata.AddResourceSet(residentialCustomerSet);
            metadata.AddResourceType(user);
            metadata.AddResourceSet(userSet);
			
            ResourceAssociationSet customerUserListSet = new ResourceAssociationSet(
                "CustomerUserList",
                new ResourceAssociationSetEnd(
                    customerSet,
                    customer,
                    customerUserList
                ),
                new ResourceAssociationSetEnd(
                    userSet,
                    user,
                    userCustomer
                )
            );
            customerUserList.CustomState = customerUserListSet;
            userCustomer.CustomState = customerUserListSet;
            metadata.AddAssociationSet(customerUserListSet);
			
            return metadata;
        }
        public ODataServiceQueryProvider<T> GetQueryProvider(ODataServiceMetadataProvider metadata)
        {
            return new ODataServiceQueryProvider<T>(metadata);
        }
		
        public ODataServiceUpdateProvider<T> GetUpdateProvider(ODataServiceMetadataProvider metadata, ODataServiceQueryProvider<T> query)
        {
            return new ODataServiceUpdateProvider<T>(metadata, query);
        }
        public ODataService()
        {
            _metadata = GetMetadataProvider(typeof(T));
            _query = GetQueryProvider(_metadata);
            _updater = GetUpdateProvider(_metadata, _query);
        }
    }
