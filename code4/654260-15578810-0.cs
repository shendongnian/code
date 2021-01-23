    class Foo
    {
       public IOutputFormatter Formatter {get;set;}
    }
    var foo = new Foo();
    foo.Formatter = new GeneralFormatter();
    Console.WriteLine(foo.formatter.FormatValue("one");
    foo.Formatter = new FizzBuzzFormatter();
    Console.WriteLine(foo.formatter.FormatValue("one");
    
