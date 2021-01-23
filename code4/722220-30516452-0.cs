        public static object Sum(this IQueryable source, string member)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (member == null) throw new ArgumentNullException("member");
            // Properties
            PropertyInfo property = source.ElementType.GetProperty(member);
            FieldInfo field = source.ElementType.GetField(member);
            ParameterExpression parameter = Expression.Parameter(source.ElementType, "s");
            Expression selector = Expression.Lambda(Expression.MakeMemberAccess(parameter, (MemberInfo)property ?? field), parameter);
            // We've tried to find an expression of the type Expression<Func<TSource, TAcc>>,
            // which is expressed as ( (TSource s) => s.Price );
            // Method
            MethodInfo sumMethod = typeof(Queryable).GetMethods().First(
                m => m.Name == "Sum"
                    && (property != null || field != null)
                    && (property == null || m.ReturnType == property.PropertyType) // should match the type of the property
                    && (field == null || m.ReturnType == field.FieldType) // should match the type of the property
                    && m.IsGenericMethod);
            return source.Provider.Execute(
                Expression.Call(
                    null,
                    sumMethod.MakeGenericMethod(new[] { source.ElementType }),
                    new[] { source.Expression, Expression.Quote(selector) }));
        }
