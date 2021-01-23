    class MainClass
    {
      public static void Execute()
      {
        SomeClass someClass = new SomeClass{
            Property = "Value"
        };
        var search = new ClassSearch(s => ((SomeClass)s).Property);
        Console.Out.WriteLine("{0} = '{1}'", search.Property.Name, search.Property.GetValue(someClass));
      }
    }
    internal class Reflector
    {
      public static string GetPropertyName<TProp>(Expression<Func<object, TProp>> e)
      {
        if (e.Body.NodeType != ExpressionType.MemberAccess)
        {
          throw new ArgumentException("Wrong expression!");
        }
        MemberExpression me = ((MemberExpression) e.Body);
  
        return me.Member.Name;
      }
    }
  
    public class ClassSearch
    {
      public ClassSearch(Expression<Func<object, object>> e)
      {
        Property = new PropertyNameAndValue(e);
      }
  
      public PropertyNameAndValue Property { get; private set; }
  
  
      public override string ToString()
      {
        return String.Format("{0} = '{1}'", Property.Name, Property);
      }
    }
    public class PropertyNameAndValue
    {
      private readonly Func<object, object> _func;
      public PropertyNameAndValue(Expression<Func<object, object>> e)
      {
        _func = e.Compile();
        Name = Reflector.GetPropertyName(e);
      }
      public object GetValue(object propOwner)
      {
        return _func.Invoke(propOwner);
      }
  
      public string Name { get; private set; }
    }
    internal class SomeClass
    {
      public string Property { get; set; }
    }
