    var productRepository = new GenericRepository<Product>();
    var productIds = productRepository.GetAll().Select(x => x.ProductId)
    
    var customerRepository = new GenericRepository<Customer>();
    
    // ProductId is IN Products
    var customersInProducts = customerRepository.Filter(c => productIds.Contains(c.ProductId));
    
    // ProductId is NOT IN Products
    var customersNotInProducts = customerRepository.Filter(c => !productIds.Contains(c.ProductId));
