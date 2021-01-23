        private static void DumpExpression(Expression expression)
        {
            var lambda = expression as LambdaExpression;
            if(lambda != null)
            {
                DumpExpression(lambda.Body);
                return;
            }
            var init = expression as MemberInitExpression;
            if(init != null)
            {
                foreach(var binding in init.Bindings)
                {
                    var assignment = (MemberAssignment) binding;
                    DumpExpression(assignment.Expression);
                    return;
                }
            }
            var methodCallExpression = expression as MethodCallExpression;
            if(methodCallExpression != null)
            {
                //Create a func that retrieves the real value of the object the method call
                //   is being evaluated on and get the Name property from it
                var objectGetExpression = Expression.Lambda<Func<Evaluator>>(methodCallExpression.Object);
                var objectGetFunc = objectGetExpression.Compile();
                Console.WriteLine(objectGetFunc().Name);
                return;
            }
        }
