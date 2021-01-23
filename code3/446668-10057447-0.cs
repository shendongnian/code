    class Program
    {
        static void Main()
        {
            Loop(@"c:\work", 1);
        }
    
        static void Loop(string root, int nestingIndex = 0)
        {
            if (nestingIndex < 0)
            {
                return;
            }
            foreach (var folder in Directory.GetDirectories(root))
            {
                Console.WriteLine(folder);
                Loop(folder, nestingIndex - 1);
            }
        }
    }
