    namespace System.Reflection
    {
    	public static class MethodInfoExtensions
    	{
    		public static bool IsExtensionMethod(this MethodInfo method)
    		{
    			return method.IsDefined(typeof(System.Runtime.CompilerServices.ExtensionAttribute), false);
    		}
        }
    }
