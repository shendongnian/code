     class Program
     {
        static void Main(string[] args)
        {
            Console.Write("Enter in the value of the string: ");
            var s = Console.ReadLine().Trim();
            List<char> charList = s.ToList();
            int x = charList.LastIndexOf(charList.Last(char.IsLetter)) ;
            Console.WriteLine("this is the last letter {0}", x);
            Console.WriteLine("This is the length of the string {0}", charList.Count);
            Console.WriteLine("We should have the last {0} characters removed", charList.Count - x);
            Console.WriteLine(s.Substring(0, x + 1);
            Console.ReadLine();
        }
    }
