    // Extension method that allows updating a property
    // and calling .Save() in a single line of code.
    public static class ISaveableExtensions
    {
    	public static void UpdateAndSave<T>(
    		this ISaveable instance,
    		Expression<Func<T>> propertyExpression, T newValue)
    	{
    		// Gets the property name
    		string propertyName = ((MemberExpression)propertyExpression.Body).Member.Name;
    
    		// Updates its value
    		PropertyInfo prop = instance.GetType().GetProperty(propertyName);
    		prop.SetValue(instance, newValue, null);
    
    		// Now call Save
    		instance.Save();
    	}
    }
    ...
    // Some interface that implements the Save method
    public interface ISaveable
    {
    	void Save();
    }
    ...
    // Test class
    public class Foo : ISaveable
    {
    	public string Property { get; set; }
    
    	public void Save()
    	{
    		// Some stuff here
    		Console.WriteLine("Saving");
    	}
    
    	public override string ToString()
    	{
    		return this.Property;
    	}
    }
    ...
    public class Program
    {
    	private static void Main(string[] args)
    	{
    		Foo d = new Foo();
    
    		// Updates the property with a new value, and automatically call Save
    		d.UpdateAndSave(() => d.Property, "newValue");
    
    		Console.WriteLine(d);
    		Console.ReadKey();
    	}
    }
