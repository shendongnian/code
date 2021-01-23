        Employee emp; // = your new employee instance
        Employee oldEmployee = session.Query<Employee>()
            .Where(x => x.Idc == emp.Idc)
            .Where(x => x.Ide == emp.Ide)
            .Single();
        oldEmployee.Property1 = emp.Property1;
        oldEmployee.Property2 = emp.Property2;
        // other properties
        session.SaveOrUpdate(oldEmployee);
