    private static void Main(string[] args)
        {
            var numbers = new[]{ 10, 9, 100, 73, 3457 };
            var ops = new[] { "*","-","/","+" };
            if (numbers.Length != ops.Length + 1)
                throw new Exception("TODO");
            string statement = numbers[0].ToString();
            for (int i = 0; i < ops.Length; i++)
            {
                statement += string.Format(" {0} {1}", ops[i], numbers[i + 1]);
            }
            Console.WriteLine("Statement: " + statement);
            var method = String.Format(@"int Product() {{ return {0}; }} ", statement);
            Console.WriteLine("Method: " + method);
            var Product = CSScript.Evaluator.CreateDelegate(method);
            int result = (int)Product();
            Console.WriteLine(result);
        }
