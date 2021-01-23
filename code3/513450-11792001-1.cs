    delegate void AddNumber(int number);
    class LambdaExpressionSample
    {
        static void Main(string[] args)
        {
            AddNumber method = r =>
            {
                Console.WriteLine(r + r);
                Console.Read();
            };
            method(1);
        }
    }
