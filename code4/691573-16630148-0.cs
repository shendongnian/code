    public IEnumerable<CustomerItem> GetOrdersFromCustomerItem(int id)
    {
      // You must select CustomerItem not a customer in the previous linq query.
      return (from c in this.dax.Customer
           where c.Id.CompareTo(id) == 0
           select new CustomerItem{
           	}).AsEnumerable().ToList();
    }
