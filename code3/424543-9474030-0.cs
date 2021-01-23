    using System;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.Clear();
                Console.WriteLine("Press X to quit");
                Console.TreatControlCAsInput = false;
                Console.CancelKeyPress += (s, ev) =>
                                              {
                                                  Console.WriteLine("Ctrl+C pressed");
                                                  ev.Cancel = true;
                                              };
    
                while (true)
                    if (Console.ReadKey().Key == ConsoleKey.X)
                        break;
            }
        }
    }
