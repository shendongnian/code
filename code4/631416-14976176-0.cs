    public int CreateNewCustomer(string Name)
    {
        var role = new RoleEntity { RoleId = 1 };
        AttachEntity(role); // role is "Unchanged" now
        // Some mapping to CustomerEntity
        var customerEntity = new CustomerEntity
        {
            CustomerName = Name,
            Roles = new List<RoleEntity>{ role } // Will not set role to "Added"
        };
        
        return InsertCustomer(customerEntity);
    }
