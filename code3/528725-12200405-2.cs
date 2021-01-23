    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ExtractPath(@"C:\Temp\X\2012\08\27\18\35\wy32dm1q.qyt"));
            Console.WriteLine(ExtractPath(@"D:\Temp\X\Y\2012\08\27\18\36\tx84uwvr.puq"));
        }
        static string ExtractPath(string fullPath)
        {
            return Regex.Match(fullPath, @"\d{4}\" + Path.DirectorySeparatorChar + 
                @"(\d{2}\" + Path.DirectorySeparatorChar + @"){4}.+").Value;
        }
    }
