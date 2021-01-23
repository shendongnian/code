    public static class YourExtensions
    {
        public static void MyMethod<T>(this DbSet<T> table)
           where T: class
        {
            // code here
        }
    }
