    protected override void Seed(eManager.Web.Infrastructure.DepartmentDb context)
    {
      context.Departments.AddOrUpdate(d => d.Name,
                  new Department() { Name = "Engineering" },
                  new Department() { Name = "Sales" },
                  new Department() { Name = "Shipping" },
                  new Department() { Name = "Human Resources" });
      if (!Roles.RoleExists("Admin"))
      {
        Roles.CreateRole("Admin");
      }
      if (Membership.GetUser("wayne") == null)
      {
        Membership.CreateUser("wayne", "P@ssword");
        Roles.AddUserToRole("wayne", "Admin");
      }
