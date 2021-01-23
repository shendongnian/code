    var employee = new Employee() { Id = someId, Name = "Jack" }
    Db.Employees.Attach(employee);
    Db.Employees.Entry(employee).Property(e => e.Name).IsModified = true;
    
    Db.SaveChanges();
