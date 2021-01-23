    class Program
    {
        static string RandomString(string inputString)
        {
            var rnd = new Random();
            var result = inputString
                .Replace(" ", string.Empty)
                .ToArray()
                .OrderBy(x => rnd.Next());
            return string.Join("", result.Select(x => x.ToString()));
        }
        static void Main(string[] args)
        {
            int intValue = 23;
            DateTime dateValue = DateTime.UtcNow;
            Char charValue = 'd';
            
            var newString = string.Format("{0}{1}{2}", 
                intValue, dateValue.ToString("dd/MM/yy"), charValue);
            Console.WriteLine(newString);
            Console.WriteLine(RandomString(newString));
            Console.ReadKey();
        }
    }
