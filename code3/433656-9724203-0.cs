     var myClass = new MyClass1 { Name = "John", SurName = "Smith" };
     Console.WriteLine(MyMarshal(myClass));
    static string MyMarshal(object item)
    {
      var values = new List<object>();
      foreach (var field in item.GetType().GetFields())
      {
        values.Add(field.GetValue(item));
      }
      return string.Join(" ", values.ToArray());
    }
    public struct MyClass1 
    {  
        public string Name; 
 
        public string SurName; 
    }
