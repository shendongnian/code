    public static void DoStuff<T>(T obj)
            {
                Console.WriteLine(typeof(A).IsInstanceOfType(obj));
                Console.WriteLine(obj.GetType());
            }
