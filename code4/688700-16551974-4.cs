    using (ExampleContext db = new ExampleContext())
    {
        var newEmployee = db.Employees.Add(new Employee() { /* insert properties here */ });
        db.SaveChanges();
        db.Locations.Add(new Location() { EmployeeId = newEmployee.EmployeeId /* insert properties here */ });
        db.SaveChanges();
        var employee1 = db.Employees.First();
        var employee1Location = employee1.Location;
    }
