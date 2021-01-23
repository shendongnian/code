    class Program
    {
        static string RandomizeString(string inputString)
        {
            var rnd = new Random();
            // throw the input string into an array, sort it randomly
            // then join the resulting array back to a single string
            var result = inputString
                .ToArray()
                .OrderBy(x => rnd.Next());
            return string.Join(string.Empty, result.Select(x => x.ToString()));
        }
        static void Main(string[] args)
        {
            // explicitly simulate the 3 inputs that you mention
            int intValue = 23;
            DateTime dateValue = DateTime.UtcNow;
            Char charValue = 'd';
            
            // package to a single concatenated string
            var newString = string.Format("{0}{1}{2}", 
                intValue, dateValue.ToString("dd/MM/yy"), charValue);
            
            // show 'original version'
            Console.WriteLine(newString);
            // now the 'random' one
            Console.WriteLine(RandomizeString(newString));
            Console.ReadKey();
        }
    }
