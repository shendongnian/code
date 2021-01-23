    static void Main(string[] args)
    {
        var data = new List<MyType>() {
            new MyType() { SomeProperty = new Inner() { NestedProperty = "2" }},
            new MyType() { SomeProperty = new Inner() { NestedProperty = "1" }},
            new MyType() { SomeProperty = new Inner() { NestedProperty = "3" }},
            new MyType(),
        }.AsQueryable();
        var sorted = data.OrderBy(x => GetPropertyValue(x, "SomeProperty.NestedProperty"));
        foreach (var myType in sorted)
        {
           try
           {
              Console.WriteLine(myType.SomeProperty.NestedProperty);
           }
           catch (Exception e)
           {
              Console.WriteLine("Null");
           }
        }
    }
    public static object GetPropertyValue(object obj, string propertyName)
    {
        try
        {
            foreach (var prop in propertyName.Split('.').Select(s => obj.GetType().GetProperty(s)))
            {
                obj = prop.GetValue(obj, null);
            }
            return obj;
        }
        catch (NullReferenceException)
        {
            return null;
        }
    }
