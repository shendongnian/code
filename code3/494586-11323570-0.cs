    var result = 
        from customer in _dataContext.Customers
        join order in _dataContext.Purchases on customer.Id equals order.IdCustomer
        select new MyCustomer
        {
            Code = customer.Code,
            Firstname = customer.Firstname,
            Lastname = customer.Lastname,
            Id = customer.Id,
            Purchases = _dataContext.Purchases
                .Where(x => x.IdCustomer == customer.Id)
                .Select(x => new MyPurchase {
                    Id = x.Id,
                    Code = x.Code,
                    CreationDate = x.CreationDate
                }).ToList();
        };
