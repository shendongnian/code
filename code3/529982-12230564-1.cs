    var a = new MyClass { Name = "abc", Age = 21 };
    var b = new MyClass { Name = "abc", Age = 21 };
    var c = new MyClass { Name = "def", Age = 21 };
    Console.WriteLine(a.DoUpdate(b)); // false - the same
    Console.WriteLine(a.DoUpdate(c)); // true - different
    Console.WriteLine(a.Name); // "def" - updated
    Console.WriteLine(a.Age);
