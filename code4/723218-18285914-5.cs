    protected override void Seed(MyProject.Models.MyProjectContext context)
    {
        context.Companies.AddOrUpdate(
                p => p.Name,
                Enumerable.Range(1, 10).
                Select( x => new Company { Name = Faker.Company.Name() }).ToArray()
        );
    
        context.SaveChanges();
    }
    
    ...
