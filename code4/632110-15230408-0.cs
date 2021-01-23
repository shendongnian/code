    private IOrderedQueryable<CustomerDTO> GetOrderBy(OrderCustomersBy orderOption)
    {
        IOrderedQueryable<CustomerDTO> orderBy = null;
        
        switch (orderOption)
        {
            case OrderCustomersBy.FirstNameAsc: 
                // Create order by...
                break;
            case OrderCustomersBy.FirstNameDesc: 
                // Create order by...
                break;
            case OrderCustomersBy.AgeAsc: 
                // Create order by...
                break;
            case OrderCustomersBy.AgeDesc: 
                // Create order by...
                break;
            default:
                throw new NotImplementedException("Order option not implemented: " + orderOption.ToString());
        }
        
        return orderBy;
    }
    
    public IEnumerable<Customer> GetPaged(Func<IQueryable<Customer>> func, OrderCustomersBy orderOption, int skip, int take)
    {
        IOrderedQueryable<CustomerDTO> orderBy = this.GetOrderBy(orderOption);
        
        foreach (var customerDTO in unitOfWork.CustomerRepository.GetPaged(orderBy, skip, take))
        {
            yield return new Customer(customerDTO);
        }
    }
