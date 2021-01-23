    namespace TehHorror
    {
        using System;
        using System.Threading;    
        class Horror
        {
            private ManualResetEvent waiter = null;    
            public void Fix(ref Action multicast)
            {
                waiter = new ManualResetEvent(false);
                multicast += HorrorHandler;
                if (multicast != null) multicast();
                var tr = __makeref(multicast);
                waiter.WaitOne();
                __refvalue(tr, Action) -= HorrorHandler;
            }    
            public void Clear() { waiter.Set(); }    
            private static void HorrorHandler()
            {
                Console.WriteLine("Hello from horror handler.");
            }
        }    
        class Program
        {
            static void Main()
            {
                Action a = () => Console.WriteLine("Hello from original delegate");
                var horror = new Horror();
                a.Invoke();
                Action fix = () => horror.Fix(ref a);
                fix.BeginInvoke(fix.EndInvoke, null);
                Thread.Sleep(1000);
                horror.Clear();
                a.Invoke();
            }
        }
    }
