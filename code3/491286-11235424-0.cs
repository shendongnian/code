     var data = from c in transactions
                group c by c.BusinessName
                into business
                select new BusinessTransaction
                {
                    Name = business.Key,
                    Transactions = business.OrderBy(t => t.TransactionDateTime)
                                           .ToList()
                };
