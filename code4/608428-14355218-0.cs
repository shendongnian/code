    public static void UnknownArgumentsMethod2(params object[] list)
    {
        foreach (object o in list)
        {
            if (o.GetType() == typeof(int))
            {
                Console.WriteLine("This is an integer: " + (int)o);
            }
            else if (o.GetType() == typeof(ClassA))
            {
                Console.WriteLine("This is an object of ClassA");
            }
        }
    }
