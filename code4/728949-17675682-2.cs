    foreach (PropertyInfo propertyInfo in typeof(Employee).GetProperties())
    {
        typeof(Manager).GetMembers()
            .OfType<PropertyInfo>()
            .FirstOrDefault(p => p.Name.EndsWith(propertyInfo.Name, 
                StringComparison.CurrentCultureIgnoreCase))
            .SetValue(manager,
                propertyInfo.GetValue(employee, new object[] { }),
                    new object[] { });
    }
