        static IEnumerable<string> Enumerate()
        {
            var method = new StackTrace(true).GetFrame(0).GetMethod().DeclaringType.Name;
            yield return Regex.Replace(method, @".*<([^)]+)>.*", "$1");
        } 
        static void Main(string[] args)
        {
            foreach (var @string in Enumerate())
            {
                Console.WriteLine(@string);
            }
        }
