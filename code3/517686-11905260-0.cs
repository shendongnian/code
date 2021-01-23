    public class MyObject
    {
        public int Value;
    }
    
    public static void Main(string[] args)
    {
        MyObject obj = new MyObject();
    
        obj.Value = 42;
    
        PrintObject(obj);
    
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey(true);
    }
    
    public static void PrintObject(MyObject obj)
    {
        Console.WriteLine(obj.Value);
    }
