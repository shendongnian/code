    public class Dad 
    { 
        public static string Name { get { return "George"; }
    }
    
    public class Son : Dad
    {
        public static string Name { get{ return "Frank"; }
    }
    
    public static void Test()
    {
        Console.WriteLine(Dad.Name); // prints "George"
        Console.WriteLine(Son.Name); // prints "Frank"
        Dad actuallyASon = new Son();
        PropertyInfo nameProp = actuallyASon.GetType().GetProperty("Name");
        Console.WriteLine(nameProp.GetValue(actuallyASon, null)); // prints "Frank"
    }
