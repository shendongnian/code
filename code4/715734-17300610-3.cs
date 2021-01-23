    public class Foo
    {
        public string Bar { get; set; }
    }
    var foo = new Foo { Bar = "\n" };
    var result = XmlSerialize(foo);
    
    Console.WriteLine(result);
    var newFoo = XmlDeserialize<Foo>(result);
    
    Console.WriteLine(newFoo.Bar);
    Debug.Assert(newFoo.Bar == "\n");
