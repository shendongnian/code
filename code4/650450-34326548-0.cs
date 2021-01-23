    using (var ctx = new MyEntity())
        {
            var x = (from y in ctx.Employees
                 orderby  y.EmployeeId descending
                 select y).FirstOrDefault();
            ctx.Employees.Remove(x);
            ctx.SaveChanges();
        }
