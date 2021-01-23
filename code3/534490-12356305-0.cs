    public class Program
    {
        static void Main()
        {
            var input = "‰";
            var encoding = Encoding.GetEncoding("iso-8859-1");
            var buffer = encoding.GetBytes(input);
            input = encoding.GetString(buffer);
            // prints a ? because ISO-8859-1 cannot represent this character
            Console.WriteLine(input);
        }
    }
