      static class Program
      {
          delegate void CodeBlock();
          internal delegate void ExceptionCatcher(Exception ex);
        private static void Main()
        {
            CodeBlock b = () => { Console.WriteLine("HELLO WORLD"); };
            CodeBlock error = () => { throw new Exception("Exception thrown"); };
            ExceptionCatcher silence = exception => { };
            ExceptionCatcher e = exception =>
                {
                    var currentColor = Console.BackgroundColor;
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine(exception.Message);
                    Console.BackgroundColor = currentColor;
                };
            
            DRYRunner(b, e);
            DRYRunner(error , e);
            DRYRunner(error , silence);
            Console.ReadLine();
        }
        static void DRYRunner (CodeBlock block, ExceptionCatcher catcher)
        {
            try
            {
                block.Invoke();
            }
            catch (Exception ex)
            {
                catcher(ex);
            }
        }
    }   
