    public static class MyExtension
    {
        public static void Invoke<T>(this IQueryable<T> query) 
        {
            MyExtensionImplementation.Invoke(query);
        }
    }
    
    internal class MyExtensionImplementation
    {
        public static void Invoke<T>(IQueryable<T> query) 
        {
            //actual work
        }
    }
