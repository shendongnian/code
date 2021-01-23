    public class TestClass
    {
        public TestClass()
        {
           this.ThrowIfNull(t=>t.Str, t=>t.Test);
           //OR
           //this.ThrowIfNull(t => t.X)
           //    .ThrowIfNull(t => t.Test);
        }
        string Str = "";
        public TestClass Test {set;get;}
    }
    public static class SOExtension
    {
        public static T ThrowIfNull<T>(this T target, params Expression<Func<T, object>>[] exprs)
        {
            foreach (var e in exprs)
            {
                var exp = e.Body as MemberExpression;
                if (exp == null)
                {
                    throw new ArgumentException("Argument 'expr' must be of the form x=>x.variableName");
                }
                var name = exp.Member.Name;
                if (e.Compile()(target) == null)
                    throw new ArgumentNullException(name,"Parameter [" + name + "] can not be null");
                
            }
            return target;
        }
    }
