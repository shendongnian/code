    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                while(true)
                {
                    var s = Console.ReadLine();
    
                    if (!string.IsNullOrEmpty(s))
                    {
                        Debug.WriteLine(s);
    
                        Console.WriteLine(s);
                    }
                }
            }
        }
    }
