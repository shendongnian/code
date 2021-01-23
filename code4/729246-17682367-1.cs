    var chargables = new IChargable<Transaction>[]
        {
            new BusinessService(),
            new Product()
        };
    var transactions = chargables.Select(c => c.Charge());    
    
