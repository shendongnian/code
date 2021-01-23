    public class A<T> : B<Foobar> where T :new()
    {
    	public T MyInstance {get; set;}
    	public A()
    	{
    		MyInstance = new T();
    	}
    }
    void Main()
    {
    	B<Foobar> x = new A<Wibble>();
    	Wibble y = ((A<Wibble>)x).MyInstance;
    }
