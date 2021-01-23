    var result = InvoiceList
         .GroupBy(m => m.AdvertiserCustomerId)
         .Select(group => new Invoice {
                    AdvertiserCustomerID = group.Key,
                    GrossAmount = group.Sum(g => g.GrossAmount)
                    }
         );
