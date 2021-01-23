    public class Person
    {
    	public string FirstName { get; set; }
    
    	public string LastName { get; set; }
    
    	public int Age { get; set; }
    }
    
    public static class MyHelper
    {
    	public static void UppercaseClassFields<T>(T theInstance)
    	{
    		if (theInstance == null)
    		{
    			throw new ArgumentNullException();
    		}
    
    		foreach (var property in theInstance.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
    		{
    			var theValue = property.GetValue(theInstance, null);
    			if (theValue is string)
    			{
    				property.SetValue(theInstance, ((string)theValue).ToUpper(), null);
    			}
    		}
    	}
    
    	public static void UppercaseClassFields<T>(IEnumerable<T> theInstance)
    	{
    		if (theInstance == null)
    		{
    			throw new ArgumentNullException();
    		}
    
    		foreach (var theItem in theInstance)
    		{
    			UppercaseClassFields(theItem);
    		}
    	}
    }
    
    public class Program
    {
    	private static void Main(string[] args)
    	{
    		List<Person> myList = new List<Person>{
    			new Person { FirstName = "Aaa", LastName = "BBB", Age = 2 },
    			new Person{ FirstName = "Deé", LastName = "ève", Age = 3 }
    		};
    
    		MyHelper.UppercaseClassFields<Person>(myList);
    
    		Console.ReadLine();
    	}
    }
