    class Test
    {
        static void Main(string[] args)
        {
            if (ExpressionOne() && ExpressionTwo() != string.Empty) DoSomething();
        }
        
        static bool ExpressionOne()
        {
            // check something
        }
        
        static string ExpressionTwo()
        {
            try
            {
                return ThisMayThrowArgumentExceptionOrReturnAString();
            }
            catch (ArgumentException)
            {
                return string.Empty;
            }
        }
        
        // ...
    }
