    public class A { public string Name; }
    ...
    var orig = new A { Name = "bob" };
    var obj = orig;
    obj.Name = "joe";
    Console.WriteLine(orig.Name); //"joe"
