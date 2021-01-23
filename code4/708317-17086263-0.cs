        static void Main(string[] args)
        {
            Regex regex = new Regex(@"(?<words>[A-Za-z ]+)(?<digits>[0-9]+)");
            string input = "At the gates 42";
            var match = regex.Match(input);
            var a = match.Groups["words"].Value; //At the gates 
            var b = match.Groups["digits"].Value; //42
        }
