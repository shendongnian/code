    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    
    namespace Project1
    {
        class Class1
        {
            private static ManualResetEvent mre1 = new ManualResetEvent(false);
            private static ManualResetEvent mre2 = new ManualResetEvent(false);
    
            public static void thread1() 
            {
                Console.WriteLine("1");
                mre2.Set();
                mre1.WaitOne();
                Console.WriteLine("t2 has printed 1, so we now print 2");
                mre2.Set();
                mre1.WaitOne();
                Console.WriteLine("t2 has printed 2, so we now print 3");
            }
    
            public static void thread2()
            {
                mre2.WaitOne();
                Console.WriteLine("t1 has printed 1, so we now print 1");
                mre1.Set();
                mre2.WaitOne();
                Console.WriteLine("t1 has printed 2, so we now print 2");
                mre1.Set();
                mre2.WaitOne();
                Console.WriteLine("t1 has printed 3, so we now print 3");
            }
            
            public static void Main() {
    
                Thread t1 = new Thread(new ThreadStart(() => thread1()));
                Thread t2 = new Thread(new ThreadStart(() => thread2()));
    
                t1.Start();
                t2.Start();
    
                while (true) {
                    Thread.Sleep(1);
                }
    
            }
    
        }
    }
