    protected override void Seed(Fideli100.Models.Fideli100Context context)
    {
        context.Companies.AddOrUpdate(
                p => p.Name,
                Enumerable.Range(1, 10).
                Select( x => new Company { Name = Faker.Company.Name() }).ToArray()
            );
    }
