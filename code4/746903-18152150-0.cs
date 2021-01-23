    class Person
    {
      public string Name { get; set; }
      public int Age { get; set; }
    }
    
    static class Extensions
    {
      public static T With<T, P>(this T self, Expression<Func<T, P>> selector, P newValue)
      {
        var me = (MemberExpression)selector.Body;
        var changedProp = (System.Reflection.PropertyInfo)me.Member;
    
        var clone = Activator.CreateInstance<T>();
        foreach (var prop in typeof(T).GetProperties())
          prop.SetValue(clone, prop.GetValue(self));
    
        changedProp.SetValue(clone, newValue);
        return clone;
      }
    }
    
    class Program
    {
      static void Main(string[] args)
      {
        var person = new Person() { Name = "Tomas", Age = 1 };
        var newp = person.With(p => p.Age, 20);
        Console.WriteLine(newp.Age);
        Console.WriteLine(newp.Name);
      }
    }
