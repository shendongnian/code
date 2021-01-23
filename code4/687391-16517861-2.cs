    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    class Foo
    {
        public string A { get; set; }
        public int B; // note a field!
        static void Main()
        {
            var obj1 = new { A = "abc", B = 123 };
            var obj2 = new Foo { A = "abc", B = 123 };
            Console.WriteLine(MemberwiseComparer.AreEquivalent(obj1, obj2)); // True
    
            obj1 = new { A = "abc", B = 123 };
            obj2 = new Foo { A = "abc", B = 456 };
            Console.WriteLine(MemberwiseComparer.AreEquivalent(obj1, obj2)); // False
    
            obj1 = new { A = "def", B = 123 };
            obj2 = new Foo { A = "abc", B = 456 };
            Console.WriteLine(MemberwiseComparer.AreEquivalent(obj1, obj2)); // False
        }
    
    }
    
    public static class MemberwiseComparer
    {
        public static bool AreEquivalent(object x, object y)
        {
            // deal with nulls...
            if (x == null) return y == null;
            if (y == null) return false;
            return AreEquivalentImpl((dynamic)x, (dynamic)y);
        }
        private static bool AreEquivalentImpl<TX, TY>(TX x, TY y)
        {
            return AreEquivalentCache<TX, TY>.Eval(x, y);
        }
        static class AreEquivalentCache<TX, TY>
        {
            static AreEquivalentCache()
            {
                const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
                var xMembers = typeof(TX).GetProperties(flags).Select(p => p.Name)
                    .Concat(typeof(TX).GetFields(flags).Select(f => f.Name));
                var yMembers = typeof(TY).GetProperties(flags).Select(p => p.Name)
                    .Concat(typeof(TY).GetFields(flags).Select(f => f.Name));
                var members = xMembers.Intersect(yMembers);
    
                Expression body = null;
                ParameterExpression x = Expression.Parameter(typeof(TX), "x"),
                                    y = Expression.Parameter(typeof(TY), "y");
                foreach (var member in members)
                {
                    var thisTest = Expression.Equal(
                        Expression.PropertyOrField(x, member),
                        Expression.PropertyOrField(y, member));
                    body = body == null ? thisTest
                        : Expression.AndAlso(body, thisTest);
                }
                if (body == null) body = Expression.Constant(true);
                func = Expression.Lambda<Func<TX, TY, bool>>(body, x, y).Compile();
            }
            private static readonly Func<TX, TY, bool> func;
            public static bool Eval(TX x, TY y)
            {
                return func(x, y);
            }
        }
    }
