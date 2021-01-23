    namespace Scratch
    {
       	internal class Foo
    	{
          // A class to create
    	}
    	class Program
    	{
    		public static T GetInstance<T>() where T : class, new()
    		{
    			return new T(); // Or whatever...
    		}
    		public static T CallGeneric<T>(Func<object> f)
    		{
    			var method = f.Method;
    			var converted = method.GetGenericMethodDefinition().MakeGenericMethod(typeof(T));
    			return (T) converted.Invoke(null, new object[] {});
    		}
    		public static T GetEvenMoreGenericInstance<T>()
    		{
    			if(!typeof(T).IsValueType)
    			{
    				return CallGeneric<T>(GetInstance<object>);
    			}
    			return default(T);
    		}
    		static void Main( string[] args )
    		{
    			var a = GetEvenMoreGenericInstance<int>();
    			var b = GetEvenMoreGenericInstance<Foo>();
    		}
    	}
    }
