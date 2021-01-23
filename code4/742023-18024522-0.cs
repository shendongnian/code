    public class Foo
    {
    	public Foo()
    		: this("Hello")
    	{
    		Console.Write(" World!");
    	}
    	
    	public Foo(string text)
    	{
    		Console.Write(text);
    	}
    }
    new Foo(); //outputs "Hello World!"
