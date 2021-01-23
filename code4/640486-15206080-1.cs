    using System;
    namespace Demo
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var obj = new object();
                var wRef = new WeakReference(obj);
                GC.Collect();
                obj = null;
                GC.Collect();
                Console.WriteLine(wRef.IsAlive); // Prints false.
                Console.ReadKey();
            }
        }
    }
