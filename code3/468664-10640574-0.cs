            using (var cx1 = new customerEntities(firstDbConnectionString))
            {
                using (var cx2 = new customerEntities(secondDbConnectionString))
                {
                    return cx1.tCustomer.ToList().AddRange(cx2.tCustomer.ToList());
                }
            }
