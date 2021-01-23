                const double discout = 50;
                var items = new List<Service>()
                {
                new Service{Item = "Service1", RecurringMonthlyCharge = 10, Term = 12, Commision = 100},
                new Service{Item = "Service2", RecurringMonthlyCharge = 12, Term = 18, Commision = 200},
                new Service{Item = "Service3", RecurringMonthlyCharge = 14, Term = 12, Commision = 300}
                                };
                //calculate total terms
                double totalTerms = items.Sum(x => x.Term);
                var searchedItems = items.Select(service => service.RecurringMonthlyCharge - (discout/totalTerms)*service.Term);
