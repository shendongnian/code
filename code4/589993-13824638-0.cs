        public IQueryable<ItemSummary> GetAll()
        {
            IQueryable<ItemSummary> items = context.Items
                .Select(c => new ItemSummary {
                       FirstProfileName = c.UserProfile.FullName,
                       SecondProfileName = c.UserProfile1.FullName,
                       ScalarProp1 = c.ScalarProp1,
                       ...
                    })
                .AsQueryable();
            return items;
        }
