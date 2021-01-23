    public class Foo
    {
      public string Name { get; set; }
    
      public Foo(string name)
      {
        Name = name;
      }
    
      public string GetName()
      {
        return Name;
      }
    }
    var test = new Foo("test");
    Console.WriteLine(test.GetName());
