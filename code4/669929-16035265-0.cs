    enum Comparision
    {
            AND,
            OR
    }
    class Program
    {
        static void Main(string[] args)
        {
            Comparision cmp = (Comparision)Enum.Parse(typeof (Comparision), "And", true);
            Console.WriteLine(cmp == Comparision.OR  );
            Console.WriteLine(cmp == Comparision.AND);
        }
    }
