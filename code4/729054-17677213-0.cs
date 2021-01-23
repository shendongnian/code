    using Microsoft.VisualBasic;
    class Program
    {
        static void Main(string[] args)
        {
            var input = "123";
            var length = 6;
            var lSet = Strings.LSet(input, length);
            var rSet = Strings.RSet(input, length);
            // you could also have the same functionality 
            // without having to use LSet and RSet
            var padR = input.Substring(0, 
                    Math.Min(input.Length, length))
                .PadRight(length, ' ');
            var padL = input.Substring(0, 
                    Math.Min(input.Length, length))
                .PadLeft(length, ' ');
            Console.WriteLine(lSet == padR);
            Console.WriteLine(rSet == padL);
        }
    }
