    public interface ICreator<T>
    {
    	void WriteName();
    }
    
    public class Creator<T> : ICreator<T>
    {
    	public void WriteName()
    	{
    		Console.WriteLine("I'm standard creator: " + typeof(T).FullName);
    	}
    }
    
    public class CustomIntCreator : ICreator<int>
    {
    	public void WriteName()
    	{
    		Console.WriteLine("I'm custom int creator");
    	}
    }
    
    class Program
    {
    	static void Main(string[] args)
    	{
    		ContainerBuilder cb = new ContainerBuilder();
    		cb.RegisterGeneric(typeof (Creator<>)).As(typeof (ICreator<>));
    		cb.RegisterType<CustomIntCreator>().As<ICreator<int>>();
    		var container = cb.Build();
    
    		var intCreator = container.Resolve<ICreator<int>>();    		
            var customCreator = container.Resolve<ICreator<double>>(); 
    		intCreator.WriteName(); //writes "I'm custom int creator"
    		customCreator.WriteName(); //writes "I'm standard creator: System.Double"
    		
    		Console.ReadLine();
    	}
    }
