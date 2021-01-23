    void Main()
    {
    	dynamic objectToProcess = new Moop();
    	
    	DoStuff(objectToProcess); //Dynamic dispatch will pick the best match automatically
    }
    
    public void DoStuff(Moop obj)
    {
    	Console.WriteLine(obj.GetType());
    }
    
    public void DoStuff(Gloop obj)
    {
    	Console.WriteLine(obj.GetType());
    }
    
    public void DoStuff(Bloop obj)
    {
    	Console.WriteLine(obj.GetType());
    }
    
    public class Moop {}
    public class Gloop {}
    public class Bloop {}
