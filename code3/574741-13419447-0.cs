    class CloseConnectionInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Type genericType = invocation.Method.ReturnType.IsGenericType
                ? invocation.Method.ReturnType.GetGenericTypeDefinition()
                : null;
            if (genericType == typeof(IEnumerable<>))
            {
                invocation.Proceed();
                var method = GetType()
                    .GetMethod("HandleIteratorInvocation")
                    .MakeGenericMethod(
                        invocation.Method.ReturnType.GetGenericArguments()[0]);
                invocation.ReturnValue = method.Invoke(
                    null,
                    new[] { invocation.InvocationTarget, invocation.ReturnValue });
            }
            else
            {
                HandleNonIteratorInvocation(invocation);
            }
        }
        public static IEnumerable<T> HandleIteratorInvocation<T>(
            IHasConnection hasConnection, IEnumerable enumerable)
        {
            try
            {
                foreach (var element in enumerable)
                    yield return (T)element;
            }
            finally
            {
                CloseOpenConnection(hasConnection);
            }
        }
        private static void HandleNonIteratorInvocation(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            finally
            {
                CloseOpenConnection(invocation.InvocationTarget as IHasConnection);
            }
        }
        private static void CloseOpenConnection(IHasConnection hasConnection)
        {
            if (hasConnection.IsConnectionOpen)
            {
                hasConnection.Connection.Dispose();
                hasConnection.Connection = null;
            }
        }
    }
