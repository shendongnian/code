    namespace ConsoleApplication1
    {
        public delegate void ProcessCompletedEvent(string description);
    
        public class Class1
        {
            public void Func1()
            {
                // Do Func1 work
                Thread.Sleep(500);
                RaiseEvent("Func1 completed");
            }
            public void Func2()
            {
                // Do Func2 work
                Thread.Sleep(1000);
                RaiseEvent("Func2 completed");
            }
            private void RaiseEvent(string description)
            {
                if (ProcessCompleted != null)
                {
                    ProcessCompleted(description);
                }
            }
    
            public event ProcessCompletedEvent ProcessCompleted;
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Class1 cs1 = new Class1();
    
                // Wire up event handler
                cs1.ProcessCompleted += new ProcessCompletedEvent(MyHandler);
    
                cs1.Func1();
                cs1.Func2();
    
                Console.Read();
                // Remove the subscription
                cs1.ProcessCompleted -= MyHandler;
            }
    
            // *** Is in the same scope as main, which subscribes / desubscribes
            public static void MyHandler(string description)
            {
                Console.WriteLine(description);
            }
        }
    }
