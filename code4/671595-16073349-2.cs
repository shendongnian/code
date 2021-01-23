    var institutions = from x in context.Institutions
                       where {blah}
                       let hasDepartments = x.Departments.Any(d => d.Active == false 
                                       && i.IsDeleted == false)
                       select new { Department = x, AllSet = hasDepartments};
    foreach(var institution in institutions)
    {
        //DO STUFF
    }
