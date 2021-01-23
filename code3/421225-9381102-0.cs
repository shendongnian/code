    void Main()
    {
    	B<Foobar> x = new A<Wibble>();
    
    }
    
    // Define other methods and classes here
    public class Foobar
    {
    }
    
    public class Wibble : Foobar
    {
    }
    
    public class B<U>
    {
    }
    
    public class A<T> : B<Foobar>
    {
    }
