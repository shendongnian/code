    public partial class MyDataContext: IODataContext
    {
        private List<Customer> _customers = null;
        public List<Customer> Customers
        {
            get
            {
                if (_customers == null)
                {
                    _customers = DataManager.GetCustomers);
                }
                return _customers;
            }
        }
        private List<ResidentialCustomer> _residentialCustomers = null;
        public List<ResidentialCustomer> ResidentialCustomers
        {
            get
            {
                if (_residentialCustomers == null)
                {
                    _residentialCustomers = DataManager.GetResidentialCustomers();
                }
                return _residentialCustomers;
            }
        }
        private List<User> _users = null;
        public List<User> Users
        {
            get
            {
                if (_users == null)
                {
                    _users = DataManager.GetUsers();
                }
                return _users;
            }
        }
        public IQueryable GetQueryable(ResourceSet set)
        {
            if (set.Name == "Customers") return Customers.AsQueryable();
            if (set.Name == "ResidentialCustomers") return ResidentialCustomers.AsQueryable();
            if (set.Name == "Users") return Users.AsQueryable();
            throw new NotSupportedException(string.Format("{0} not found", set.Name));
        }
        public object CreateResource(ResourceType resourceType)
        {
            if (resourceType.InstanceType == typeof(Customer))
            {
                return new Customer();
            }
            if (resourceType.InstanceType == typeof(ResidentialCustomer))
            {
                return new ResidentialCustomer();
            }
            if (resourceType.InstanceType == typeof(User))
            {
                return new User();
            }
            throw new NotSupportedException(string.Format("{0} not found for creating.", resourceType.FullName));
        }
        public void AddResource(ResourceType resourceType, object resource)
        {
            if (resourceType.InstanceType == typeof(Customer))
            {
                Customer i = resource as Customer;
                if (i != null)
                {
                    Customers.Add(i);
                    return;
                }
            }
            if (resourceType.InstanceType == typeof(ResidentialCustomer))
            {
                ResidentialCustomeri = resource as ResidentialCustomer;
                if (i != null)
                {
                    ResidentialCustomers.Add(i);
                    return;
                }
            }
            if (resourceType.InstanceType == typeof(User))
            {
                Useri = resource as User;
                if (i != null)
                {
                    Users.Add(i);
                    return;
                }
            }
            throw new NotSupportedException(string.Format("{0} not found for adding.", resourceType.FullName));
        }
        public void DeleteResource(object resource)
        {
            if (resource.GetType() == typeof(Customer))
            {
                Customers.Remove(resource as Customer);
                return;
            }
            if (resource.GetType() == typeof(ResidentialCustomer))
            {
                ResidentialCustomers.Remove(resource as ResidentialCustomer);
                return;
            }
            if (resource.GetType() == typeof(User))
            {
                Users.Remove(resource as User);
                return;
            }
            throw new NotSupportedException(string.Format("{0} not found for deletion.", resource.GetType().FullName));
        }
        public void SaveChanges()
        {
            foreach (var item in Customers.Where(i => i.IsModified == true))
                item.Save();
            foreach (var item in ResidentialCustomers.Where(i => i.IsModified == true))
                item.Save();
            foreach (var item in Users.Where(i => i.IsModified == true))
                item.Save();
        }
    }
