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
            }
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
                    {typeof (ArgumentException), exception => Console.WriteLine("Check your arguments")},
                    {typeof (Exception), exception => Console.WriteLine("An exception has been thrown")}
                }
            };
            ehd.Run();
            ehd.codeBlock = () => { throw new Exception("An exception has been thrown"); };
            ehd.Run();
            Console.ReadLine();
        }
         
    }   
