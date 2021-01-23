    class Program
    {
        static void Main(string[] args)
        {
            string a = "12,1,______,_,__;1,23,122;";
            var regex = new Regex(@"(?<=;\d*,)\d*(?=,\d*;)");
            Console.WriteLine(regex.Match(a).Value);            
            a = "12,1,______,_,__;11,2,1;";
            Console.WriteLine(regex.Match(a).Value);
        }
    }
