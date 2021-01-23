    public class Foo
    {
      public string A { get; set; }
    }
    public class Example
    {
      public void GetPropertyValueExample()
      {
        Foo f = new Foo();
        f.A = "Example";
        var val = f.GetType().GetProperty("A").GetValue(f, null);
      }
    }
