    class Program
    {
        static void Main(string[] args)
        {
            var readFile = File.ReadAllText(@"C:\test\my.txt");
            var str = readFile.Split(new char[] { ' ', '\n'}, StringSplitOptions.RemoveEmptyEntries);
            System.Console.WriteLine("Number of words: " + str.Length);
        }
    }
}
