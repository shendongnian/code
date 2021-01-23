    using System;
    using System.Linq.Expressions;
    
    class Test
    {    
        static Expression<Func<T, bool>> TransformToPredicate<T>(
            Expression<Func<T, int>> prodIdProperty,
            int productId)
        {
            Expression equals = Expression.Equal(prodIdProperty.Body,
                                                 Expression.Constant(productId));
            return Expression.Lambda<Func<T, bool>>(equals, prodIdProperty.Parameters);
        }
        
        static void Main()
        {
            Expression<Func<string, int>> length = x => x.Length;
            
            var predicate = TransformToPredicate(length, 5);
            var compiled = predicate.Compile();
            
            Console.WriteLine(compiled("Hello")); // True
            Console.WriteLine(compiled("Foo")); // False
        }
    }
