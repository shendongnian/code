    protected override void Seed(SpoeDbContext context)
    {
        for (int i = 0; i < 10; i++)
        {
            context.Companies.AddOrUpdate(
                    p => p.Name,
                    new Company { Name = Faker.Company.Name() }
                );
        }
    }
