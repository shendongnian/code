    public class A 
    {
	    private readonly ILibrary _library;
		
	    public A(ILibrary library)
		{
			_library = library;
		}
    
        public DoSomething()
        {
            _library.DoStuff();
        }    
    }
    
    public class B
    {
	    private readonly ILibrary _library;
		
	    public B(ILibrary library)
		{
			_library = library;
		}
    
        public DoSomething()
        {
            _library.DoStuff();
        }      
    }
    
	public interface ILibrary
	{
	    void DoStuff();
	}
	
    public class LibraryTypeOne : ILibrary
    {
        void DoStuff()
		{
		     Console.WriteLine("I am library type one");
		}
    }
	
	public class LibraryTypeTwo : ILibrary
    {
        void DoStuff()
		{
		     Console.WriteLine("I am library type two");
		}
    }
    
    public static class MyProgram
    {
        var a = new A(new LibraryTypeOne());    //will be an singleton
        var b = new B(new LibraryTypeTwo());    //will be an singleton
    
        a.DoSomething();
        b.DoSomething();
    }
