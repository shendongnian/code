    public static class IDbConnectionExtensions {
        public static void MyExtension(this IDbConnection connection) {
            Console.WriteLine("Hello, connection!");
        }
    }
