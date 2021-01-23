    static void Main(string[] args)
    {
        try
        {
            Directory.CreateDirectory(@"D:\ParentDir\ChildDir\SubChildDir\");
            Console.WriteLine("Directories Created");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
