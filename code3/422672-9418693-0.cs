    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class IdAttribute : Attribute
    {
    	public IdAttribute(string id)
    	{
    		this.Id = id;
    	}
    
    	public string Id { get; set; }
    }
    
    public interface IMyInterface
    {
    }
    
    public abstract class BaseClass : IMyInterface
    {
    	public static string GetId<T>() where T : IMyInterface
    	{
    		return ((IdAttribute)typeof(T).GetCustomAttributes(typeof(IdAttribute), true)[0]).Id;
    	}
    }
    
    [Id("A")]
    public class ImplA : BaseClass
    {
    }
    
    [Id("B")]
    public class ImplB : BaseClass
    {
    }
    
    internal class Program
    {
    	private static void Main(string[] args)
    	{
    		var val1 = BaseClass.GetId<ImplA>();
    
    		var val2 = BaseClass.GetId<ImplB>();
    
    		Console.ReadKey();
    	}
    }
