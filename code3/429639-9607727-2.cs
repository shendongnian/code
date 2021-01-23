    class Program
    {
        static string RandomString(string inputString)
        {
            var rnd = new Random();
            // throw the input string into an array, sort it randomly
            // then join the resulting array back to a single string
            var result = inputString
                .ToArray()
                .OrderBy(x => rnd.Next());
            return string.Join("", result.Select(x => x.ToString()));
        }
        static void Main(string[] args)
        {
            // explicitly simulate the 3 inputs that you mention
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
