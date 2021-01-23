    void UpgradeToCustomer(Prospect p)
    {
        var customer = new Customer
        {
            Entity = p.Entity
        };
        
        p.Entity = null; // prevent cascading
        
        session.Delete(p);
        session.Save(customer);
    }
