    public class Foo
    {
       public Color? Color { get; set; }
    }
    // ...
    var foo = new Foo();
    Assert.IsNull(foo);     // success!
