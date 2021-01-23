    public class A
    {
      int integer{get; set;}
    }
    
    PropertyInfo prop = typeof(A).GetProperty("integer");
    A a = new A();
    prop.GetValue(a, null);
    prop.SetValue(a, 1234, null);
