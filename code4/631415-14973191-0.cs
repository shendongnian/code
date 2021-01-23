    public int? InsertCustomer(CustomerEntity customer, int roleId)
    {
        var role =_context.Roles.Find(customer);
        _customerEntity Roles = new List<RoleEntity>{ role };
        return _context.SaveChanges();
    }
