    Type studentType = typeof (Student);
    var properties = studentType.GetProperties().Where(x => x.GetCustomAttribute<UseInOrderByAttribute>() != null);
    var orderByProperty = properties.FirstOrDefault(x => x.GetCustomAttribute<UseInOrderByAttribute>().Order == 0);
    if (orderByProperty  == null)
        throw new Exception("");
    var sortedStudents = students.OrderBy(BuildPredicate(orderByProperty.Name));
    foreach (var property in properties.Where(x => x.Name != orderByProperty.Name))
    {
        sortedStudents = sortedStudents.ThenBy(BuildPredicate(property.Name));
    }
            
    var result = sortedStudents.ToList();
