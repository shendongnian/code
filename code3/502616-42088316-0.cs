    using System;
    using System.Linq.Expressions;
    namespace Validation
    {
       public static class Validator
       {
         public static void ThrowIfNull(Expression<Func<object>> expression)
         {
           var body = expression.Body as MemberExpression;
           if( body == null)
           {
             throw new ArgumentException(
               "expected property or field expression.");
           }
           var compiled = expression.Compile();
           var value = compiled();
           if( value == null)
           {
             throw new ArgumentNullException(body.Member.Name);
           }
         }
       }
