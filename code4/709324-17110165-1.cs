    public static class YourExtensions
    {
        public static void MyMethod<T>(this DbSet<T> table)
           where T: class // this constraint is required because DbSet<T> have it
        {
            // code here
        }
    }
