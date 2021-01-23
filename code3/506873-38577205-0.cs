    public static class MyExtensions
    {
    	public static System.Type Type<T>(this T v)=>typeof(T);
    }
    
    var i=0;
    console.WriteLine(i.Type().FullName);
