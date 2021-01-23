    static void Main(string[] args)
    {
        TestCreation(10000, 1000);
        Console.ReadLine();
    }
    
    private static void TestCreation(int iterations, int length)
    {
        char[] chars = GetChars(length).ToArray();
        string str = new string(chars);
        Console.WriteLine("Sending String as IEnumerable<char>");
        TestCreateMethod(str, iterations);
        Console.WriteLine("===========================================================");
        Console.WriteLine("Sending char[] as IEnumerable<char>");
        TestCreateMethod(chars, iterations);
        Console.ReadKey();
    }
    
    private static void TestCreateMethod(IEnumerable<char> testData, int iterations)
    {
        TestFunc(chars => new string(chars.ToArray()), testData, iterations, "new string");
        TestFunc(chars =>
        {
            var sb = new StringBuilder();
            foreach (var c in chars)
            {
                sb.Append(c);
            }
            return sb.ToString();
        }, testData, iterations, "sb inline");
        TestFunc(string.Concat, testData, iterations, "string.Concat");
    }
