    void Main()
    {
    	var foo = new Foo() { StringProperty = "Hello!" };
    	Console.WriteLine(TakeAProperty(() => foo.StringProperty));
    }
    
    public class Foo
    {
    	public string StringProperty {get; set;}
    }
