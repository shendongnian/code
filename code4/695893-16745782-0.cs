    namespace ConsoleApplication2
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			var x = new MyDerivedClass();
    			Console.WriteLine(x.ToString());
    			Console.WriteLine(x.Instance.ToString());
    
    			Console.ReadKey();
    		}
    	}
    
    
    	public abstract class MyBaseClass<T> where T : class, new()
    	{
    		protected T GetInstance()
    		{
    			if (_instance == null)
    			{
    				lock (_lockObj)
    				{
    					if (_instance == null)
    						_instance = new T();
    				}
    			}
    			return _instance;
    		}
    
    		public T Instance
    		{
    			get { return GetInstance(); }
    		}
    
    		private volatile static T _instance;
    		private object _lockObj = new object();
    	}
    
    	public class MyDerivedClass : MyBaseClass<MyDerivedClass>
    	{
    		public MyDerivedClass() { }
    	}
    
    }
