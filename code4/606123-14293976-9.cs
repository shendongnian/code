    public static Func<Student, object> BuildPredicate(string propertyName)
    {
        Type studentType = typeof(Student);
        ParameterExpression studentParam = Expression.Parameter(studentType, "x");
        MemberInfo ageProperty = studentType.GetProperty(propertyName);
        MemberExpression valueInNameProperty = Expression.MakeMemberAccess(studentParam, ageProperty);
        UnaryExpression expression = Expression.Convert(valueInNameProperty, typeof (object));
        Expression<Func<Student, object>> orderByExpression = Expression.Lambda<Func<Student, object>>(expression, studentParam);
        return orderByExpression.Compile();
    }
