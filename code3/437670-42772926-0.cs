        static class MethodInfoHelper<T>
        {
            static MethodInfoHelper()
            {
                VerifyTypeIsDelegate();
            }
            public static void VerifyTypeIsDelegate()
            {
                //Lets make sure this is only ever used in code for Func<> types
                if (!typeof(T).IsSubclassOf(typeof(Delegate)))
                {
                    throw new InvalidOperationException(typeof(T).Name + " is not a delegate type");
                }
                if (!typeof(T).Name.StartsWith("Func") && !typeof(T).Name.StartsWith("Action"))
                {
                    throw new InvalidOperationException(typeof(T).Name + " is not a Func nor an Action");
                }
            }
            private static bool HasReturnType
            {
                get { return typeof(T).Name.StartsWith("Func"); }
            }
            /// <summary>
            /// Creates an empty delegate of given type
            /// </summary>
            /// <typeparam name="T">Func or Action type to be created</typeparam>
            /// <returns>A delegate to expression doing nothing</returns>
            public static T CreateEmptyDelegate()
            {
                Type funcType = typeof(T);
                Type[] genericArgs = funcType.GenericTypeArguments;
                List<ParameterExpression> paramsExpressions = new List<ParameterExpression>();
                for (int paramIdx = 0; paramIdx < (HasReturnType ? genericArgs.Length - 1 : genericArgs.Length); paramIdx++)
                {
                    Type argType = genericArgs[paramIdx];
                    ParameterExpression argExpression = Expression.Parameter(argType, "arg" + paramIdx);
                    paramsExpressions.Add(argExpression);
                }
                Type returnType = HasReturnType ? genericArgs.Last() : typeof(void);
                DefaultExpression emptyExpression = (DefaultExpression)typeof(DefaultExpression).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null,
                    new Type[] { typeof(Type) }, null).Invoke(new[] { returnType });
                Expression<T> resultingExpression = Expression.Lambda<T>(
                    emptyExpression, "EmptyDelegate", true, paramsExpressions);
                return resultingExpression.Compile();
            }
        }
