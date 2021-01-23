      private class MyLinfuInterceptor : IInterceptor
      {
          public object Intercept(InvocationInfo info)
          {
                MethodInfo methodBeingRequested = info.TargetMethod;
                // enumerable return type
                if (methodBeingRequested.ReturnType.IsGenericType
                   && methodBeingRequested.ReturnType.GetGenericTypeDefinition() == typeof(IEnumerable<>)
                   && methodBeingRequested.ReturnType.GetGenericArguments().Length == 1)
                {
                   Type constructedEnumerator = typeof(MyEnumerator<>).MakeGenericType(methodBeingRequested.ReturnType.GetGenericArguments());
                   var result = Activator.CreateInstance(constructedEnumerator);
                   return result;
                }
            
                // code to handle other return types here...
           }
       }
