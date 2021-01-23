    class Program
    {
        static void Main(string[] args)
        {
            String str = "ThisIsAnInputString";
            Console.WriteLine(str);
            StringBuilder sb = new StringBuilder();
            str.ToCharArray().ToList().ForEach(c => sb.Append(char.IsLower(c) ? c.ToString() : " " + c.ToString()));
            str = sb.ToString().Trim(" ".ToCharArray());
            Console.WriteLine(str);
            Console.Read();
        }
    } 
