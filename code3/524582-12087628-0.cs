        static void PrintVariableName<T>(Expression<Func<T>> expression)
        {
            Console.WriteLine(((MemberExpression)expression.Body).Member.Name);
        }
        static void Main(string[] args)
        {
            var a = "Hello, world!";
            PrintVariableName(() => a);
        }
