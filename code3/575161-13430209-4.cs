    private static Entity GetEntityByPath(DataContext dataContext, string path)
    {
        List<string> pathParts = path.Split(new char[] { '/' }).ToList<string>();
        pathParts.Reverse();
        var entities =
            from entity in dataContext.Entities
            select entity;
        // Build up a template expression that will be used to create the real expressions with.
        Expression<Func<Entity, bool>> templateExpression = entity => entity.Code == "dummy";
        var equals = (BinaryExpression)templateExpression.Body;
        var property = (MemberExpression)equals.Left;
        ParameterExpression entityParameter = Expression.Parameter(typeof(Entity), "entity");
        for (int index = 0; index < pathParts.Count; index++)
        {
            string pathPart = pathParts[index];
            var entityFilterExpression =
                Expression.Lambda<Func<Entity, bool>>(
                    Expression.Equal(
                        Expression.Property(
                            BuildParentPropertiesExpression(0, entityParameter),
                            (MethodInfo)property.Member),
                        Expression.Constant(pathPart),
                        equals.IsLiftedToNull,
                        equals.Method),
                    templateExpression.Parameters);
            entities = entities.Where<Entity>(entityFilterExpression);
            // TODO: The entity.Parent.Parent.ParentID == 0 part is missing here.
        }
        return entities.Single<Entity>();
    }
    private static Expression BuildParentPropertiesExpression(int numberOfParents, ParameterExpression entityParameter)
    {
        if (numberOfParents == 0)
        {
            return entityParameter;
        }
        var getParentMethod = typeof(Entity).GetProperty("Parent").GetGetMethod();
        var property = Expression.Property(entityParameter, getParentMethod);
        for (int count = 2; count <= numberOfParents; count++)
        {
            property = Expression.Property(property, getParentMethod);
        }
        return property;
    }
