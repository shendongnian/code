      MethodInfo ContainsOffOfIEnumerable = OverloadedMethodFinder.FindOverloadedMethodToCall("Contains", typeof(Enumerable), typeof(IEnumerable<Z>), typeof(Z))
                                                  .MakeGenericMethod(typeof(Z));
            //grab the lst and make it a constants
            ConstantExpression ConstantListExpressionParameter = Expression.Constant(ListToCheck, typeof(IEnumerable<Z>));
            //this is an extension method so you pass in the list too
            //now create the call...basically contains(myList,int to check for)
            MethodCallExpression ContainsMethodCall = Expression.Call(ContainsOffOfIEnumerable, ConstantListExpressionParameter, RightHandSide.PropertyMemberExpression);
            //return the expression now
            return Expression.Lambda<Func<T, bool>>(ContainsMethodCall, RightHandSide.ParametersForExpression);
