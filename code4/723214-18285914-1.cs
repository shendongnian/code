    protected override void Seed(MyProject.Models.MyProjectContext context)
        {
            context.Customers.AddOrUpdate(
                c => c.Name,
                new Customer { Name = Faker.Name.FullName() }
            );
            context.SaveChanges();
    
            ...
