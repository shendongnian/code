    class MainClass
    {
       public static void Execute()
       {
           SomeClass someClass = new SomeClass{
               Property = "Value"
           };
           var prop = new ClassSearch<SomeClass, string>(s => s.Property);
           Console.Out.WriteLine("{0} = '{1}'", prop.Property.Name, prop.Property.GetValue(someClass));
       }
    }
    internal class Reflector
    {
        public static string GetPropertyName<TOwner, TProp>(Expression<Func<TOwner, TProp>> e)
        {
            if (e.Body.NodeType != ExpressionType.MemberAccess)
            {
                throw new ArgumentException("Wrong expression!");
            }
            MemberExpression me = ((MemberExpression) e.Body);
            return me.Member.Name;
        }
    }
    public class ClassSearch<TOwner, TProp>
    {
        public ClassSearch(Expression<Func<TOwner, TProp>> e)
        {
            Property = new PropertyNameAndValue<TOwner, TProp>(e);
        }
        public PropertyNameAndValue<TOwner, TProp> Property { get; private set; }
        public override string ToString()
        {
            return String.Format("{0} = '{1}'", Property.Name, Property);
        }
     }
     public class PropertyNameAndValue<TOwner, TValue>
     {
         private readonly Func<TOwner, TValue> _func;
         public PropertyNameAndValue(Expression<Func<TOwner, TValue>> e)
         {
             _func = e.Compile();
             Name = Reflector.GetPropertyName(e);
         }
         public TValue GetValue(TOwner propOwner)
         {
             return _func.Invoke(propOwner);
         }
         public string Name { get; private set; }
     }
     internal class SomeClass
     {
         public string Property { get; set; }
     }
