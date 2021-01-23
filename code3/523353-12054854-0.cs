    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class SimplePropertyAttribute : Attribute
    {
    }
    
    public class Employee { }
    
    public class Person
    {
    	[SimpleProperty]
    	virtual public long Code { get; set; }
    
    	[SimpleProperty]
    	virtual public string Title { get; set; }
    
    	virtual public Employee Employee { get; set; }
    }
    
    internal class Program
    {
    	private static void Main(string[] args)
    	{
    		foreach (var prop in typeof(Person)
    			.GetProperties()
    			.Where(z => z.GetCustomAttributes(typeof(SimplePropertyAttribute), true).Any()))
    		{
    			Console.WriteLine(prop.Name);
    		}
    
    		Console.ReadLine();
    	}
    }
