    class Program
    {
        static Dictionary<string, string> _dict = new Dictionary<string, string>();
        static void Main(string[] args)
        {
            _dict.Add("{Jwala Vora#3/13}","someValue1");
            _dict.Add("{Amazon Vally#2/11}", "someValue2");
            _dict.Add("{1#3/75}", "someValue3");
            _dict.Add("{MdOffice employee#1/1}", "someValue4");
            var input = @"Proposal is given to {Jwala Vora#3/13} for {Amazon Vally#2/11} {1#3/75} by {MdOffice employee#1/1}";
            var result = Regex.Replace(input, @"{.*?}", Evaluate);
            Console.WriteLine(result);
        }
        private static string Evaluate(Match match)
        {
            return _dict[match.Value];
        }
    }
