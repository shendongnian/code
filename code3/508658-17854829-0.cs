    public object[] GetCustomers()
    {
        return GetEntityCount("Customers");
    }
    private object[] GetEntityCount(string entityName)
    {
        return (from obj in GetSpecificEntity(entityName) join pin ...).ToArray();
    }
    private IEnumerable GetSpecificEntity(string entityName)
    {
        switch (entityName)
        {
            case "Customers": return db.Customers;
        }
    }
