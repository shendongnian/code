    Type studentType = typeof (Student);
    var properties = studentType.GetProperties()
                                .Select(x => new { Property = x, OrderAttribute = x.GetCustomAttribute<UseInOrderByAttribute>() })
                                .Where(x => x.OrderAttribute != null)
                                .OrderBy(x => x.OrderAttribute.Order);
    var orderByProperty = properties.FirstOrDefault(x => x.OrderAttribute.Order == 0);
    if (orderByProperty  == null)
        throw new Exception("");
    var sortedStudents = students.OrderBy(BuildPredicate(orderByProperty.Property.Name));
    foreach (var property in properties.Where(x => x.Property.Name != orderByProperty.Property.Name))
    {
        sortedStudents = sortedStudents.ThenBy(BuildPredicate(property.Property.Name));
    }
            
    var result = sortedStudents.ToList();
