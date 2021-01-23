        protected static object InvokeOldOperation<TCurrentInterface>(MethodInfo oldOperationMethod, object implToTest, TCurrentInterface mockCurrentImpl)
        {
            MethodInfo currentInterfaceMethod = typeof(TCurrentInterface).GetMethod(oldOperationMethod.Name);
            Type oldRequestType = oldOperationMethod.GetParameters()[0].ParameterType;
            var request = Activator.CreateInstance(oldRequestType);
            Type currentRequestType = currentInterfaceMethod.GetParameters()[0].ParameterType;
            ParameterExpression instanceParameter = Expression.Parameter(typeof(TCurrentInterface), "i");
            var requestParameter = Expression.Constant(null, currentRequestType);
            MethodCallExpression body = Expression.Call(instanceParameter, currentInterfaceMethod, new Expression[] { requestParameter});
            var lambda = Expression.Lambda<Func<TCurrentInterface, object>>(body, instanceParameter).Compile();
            var response = oldOperationMethod.Invoke(implToTest, new[] {request});
            mockCurrentImpl.AssertWasCalled(lambda, opt => opt.Constraints(Is.TypeOf(currentRequestType)).Repeat.Once());
            
            return response;
        }
