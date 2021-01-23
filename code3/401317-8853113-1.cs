    using System;
    
    namespace ConsoleApplication1
    {
        class ExceptionA : Exception
        {
            public override string Message
            {
                get
                {
                    return "Exception A";
                }
            }
        }
    
        class ExceptionB : ExceptionA
        {
            public override string Message
            {
                get
                {
                    return "Exception B";
                }
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    DoThing();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Caught in 'UI' code: " + ex.Message);
                }
            }
    
            static void DoThing()
            {
                try
                {
                    throw new ExceptionB();
                }
                catch (ExceptionB ex)
                {
                    Console.WriteLine("Caught B");
                    throw;
                }
                catch (ExceptionA ex)
                {
                    Console.WriteLine("Caught A");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Caught Generic");
                }
            }
        }
    }
