    void Main()
    {
    	Delete(new Base()); // called with base
    	Delete(new Derived()); //called with derived
    }
    public void Delete(Base item)
    {
    	Console.WriteLine ("called with base");
    	GenericDelete(item);
    }
    
    public void Delete(Derived item)
    {
    	Console.WriteLine ("called with derived");
    	GenericDelete(item);
    }
    public void GenericDelete<T>(T item)
    {}
    public class Base
    {}
    
    public class Derived : Base
    {}
