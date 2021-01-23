     class ExceptionHandledDelegate
    {
        public delegate void CodeBlock();
        public delegate void ExceptionCatcher(Exception ex);
        public Dictionary<Type, ExceptionCatcher> ExceptionHandlers;
        public CodeBlock codeBlock { get; set; }
        public void Run()
        {
            try
            {
                codeBlock.Invoke();
            }
            catch (Exception ex)
            {
                var mn = ex.GetType();
                if (ExceptionHandlers.Keys.Contains(mn))
                {
                    ExceptionHandlers[mn](ex);
                }
                else throw; 
            }
        }
    }
    class CommonHandlers
    {
        public static void ArgumentHandler(Exception ex)
        {
            Console.WriteLine("Handling an argument exception");
        }
        public static void DivZeroHandler(Exception ex)
        {
            Console.WriteLine("Please don't divide by zero. It upsets the universe.");
        }
    }
    static class Program
    {
        private static void Main()
        {
            var ehd = new ExceptionHandledDelegate
            {
                codeBlock = () => { throw new ArgumentException("An argument exception has been thrown"); },
                ExceptionHandlers = new Dictionary<Type, ExceptionHandledDelegate.ExceptionCatcher>
                {
                    {typeof (ArgumentException), CommonHandlers.ArgumentHandler},
                    {typeof (DivideByZeroException ),CommonHandlers.DivZeroHandler},
                    {typeof (Exception), exception => Console.WriteLine("An exception has been thrown")}
                }
            };
            ehd.Run();
            ehd.codeBlock = () => { throw new Exception("An exception has been thrown"); };
            ehd.Run();
            ehd.codeBlock = () =>{var denom = 0; Console.WriteLine(100 / denom);};
            ehd.Run();
            Console.ReadLine();
        }
    }
