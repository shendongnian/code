    // Init 
            NewExpression newDict = Expression.New(typeof(Dictionary<string, object>));
            // Adding a value
            List<ElementInit> elements = new List<ElementInit>();
            System.Reflection.MethodInfo addMethod = typeof(Dictionary<string, object>).GetMethod("Add");
            foreach (var fieldPath in dictionaryToBuild)
            {
                Expression valExpression = BuildLambda(fieldPath);
                elements.Add(Expression.ElementInit(addMethod, Expression.Constant(fieldPath), Expression.Convert(valExpression, typeof(object))));
            }
            var listInitExpression = Expression.ListInit(newDict, elements);
            Expression<Func<TestCaseDataResult, Dictionary<string, object>>> finalExpression = Expression.Lambda<Func<TestCaseDataResult, Dictionary<string, object>>>(listInitExpression, _parameterExpression);
            return finalExpression;
