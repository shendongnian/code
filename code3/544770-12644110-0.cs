    static class IntegerExtensions
    {
        public static int[] ToCypherArray(this int value)
        {
            var cyphers = new List<int>();
            do
            {
                cyphers.Add(value % 10);
                value = value / 10;
            } while (value != 0);
            cyphers.Reverse();
            return cyphers.ToArray();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int myNumber = 123456789;
            int[] cypherArray = myNumber.ToCypherArray();
            Array.ForEach(cypherArray, (i) => Console.WriteLine(i));
            Console.ReadLine();
        }
    }
