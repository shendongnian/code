    using System;
    using System.Threading;
    
    class Program {
        public static int CancelCount;
        static void Main(string[] args) {
            int count = 1000 * 1000 * 10;
            for (int ix = 0; ix < count; ++ix) {
                var token = new CancellationTokenSource();
                token.CancelAfter(500);
            }
            while (CancelCount < count) {
                Thread.Sleep(100);
                Console.WriteLine(CancelCount);
            }
            Console.WriteLine("done");
            Console.ReadLine();
        }
    }
    
    static class Extensions {
        public static void CancelAfter(this CancellationTokenSource source, int dueTime) {
            Timer timer = new Timer(delegate(object self) {
                Interlocked.Increment(ref Program.CancelCount);
                ((IDisposable)self).Dispose();
                try {
                    source.Cancel();
                }
                catch (ObjectDisposedException) {
                }
            });
            timer.Change(dueTime, -1);
        }
    }
