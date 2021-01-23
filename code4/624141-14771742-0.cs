    var arg = Expression.Parameter(typeof(Person), "it");
    var body = Expression.Equal(
        Expression.PropertyOrField(arg, "PersonId"),
        Expression.Constant(personId));
    if (lstPersonFields != null)
    {
        foreach (var field in lstPersonFields)
        {
            var member = Expression.PropertyOrField(arg, field.FieldName);
            switch (field.FieldCondition)
            {
                case "Contains":
                    body = Expression.AndAlso(body,
                        Expression.Call(typeof(SqlMethods), "Like", null,
                            member,
                            Expression.Constant("%" + field.FieldValue + "%")));
                    break;
                case "Equals":
                    body = Expression.AndAlso(body,
                        Expression.Equal(
                           member,
                           Expression.Constant(field.FieldValue)));
                    break;
            }
        }
    }
    var lambda = Expression.Lambda<Func<Person,bool>>(body, arg);
    var personSearch = FullPersonlst.Where(lambda).ToList();
