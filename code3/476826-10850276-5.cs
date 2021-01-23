            var property = typeof(SomeObject)
                .GetProperty("MyProperty");
            var columnType = typeof(Column<>)
                .MakeGenericType(typeof(SomeObject));
            var expressionMethod = columnType
                .GetMethod("Expression")
                .MakeGenericMethod(property.PropertyType);
            var expr = MakeMemberExpression(property);
            expressionMethod.Invoke(new Column<SomeObject>(), new[] { expr });
