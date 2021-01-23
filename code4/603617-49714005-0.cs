    using System;
    using System.Linq;
    using System.Linq.Expressions;
    
    namespace LinqTest
    {
        public class LinqCompileSubExpression
        {
            /// <summary>
            /// Compile and invoke a sub-expression of a <see cref="LambdaExpression"/>.
            /// </summary>
            /// <param name="rootExpression">A parameterised expression.</param>
            /// <param name="subExpression">An sub-expression or <paramref name="rootExpression"/>.</param>
            /// <param name="arguments">
            /// The arguments to be supplied on invoking. These must match the parameters to the root expression (empty if it has no parameters).
            /// Any parameters not used by the sub-expression are ignored.
            /// </param>
            /// <returns>The return value of the sub-expression.</returns>
            /// <typeparam name="TReturn">The type of the return value. Use <see cref="Object"/> if it is not known.</typeparam>
            /// <remarks>
            /// If invoking the same expression multiple times, use <see cref="CompileSubExpression(LambdaExpression, Expression)"/> once,
            /// then invoke the delegate (for efficiency).
            /// </remarks>
            public static TReturn InvokeSubExpression<TReturn>(LambdaExpression rootExpression, Expression subExpression, params object[] arguments)
            {
                // compile it (to a delegate):
                Delegate compiledDelegate = CompileSubExpression(rootExpression, subExpression);
    
                // invoke the delegate:
                return (TReturn)compiledDelegate.DynamicInvoke(arguments);
            }
    
            /// <summary>
            /// Compile a sub-expression of a <see cref="LambdaExpression"/>.
            /// </summary>
            /// <param name="rootExpression">A parameterised expression.</param>
            /// <param name="subExpression">An sub-expression or <paramref name="rootExpression"/>.</param>
            /// <returns>The compiled expression.</returns>
            public static Delegate CompileSubExpression(LambdaExpression rootExpression, Expression subExpression)
            {
                // convert the sub-expression to a LambdaExpression with the same parameters as the root expression:
                LambdaExpression lambda = Expression.Lambda(subExpression, rootExpression.Parameters);
    
                // compile it (to a delegate):
                return lambda.Compile();
            }
        }
    }
