    using(var tx = new Transaction())
     {
         RepositoryCustomer customers = new RepositoryCustomer(tx)
         RepositoryOrder orders = new RepositoryOrder(tx)
         var c = customers.Get(CustomerId);
         var o = orders.Get(OrderId);
     }  
