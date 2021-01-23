    Locking on local variable, the lock won's work.  Locking on global variable can take effect to synchronize multiple thread.
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        using System.Threading;
        
        namespace testLock
        {
            class Program
            {
                public static void Main()
                {
                    // Start a thread that calls a parameterized static method.
                    for(int i = 0; i< 10;i++)
                    {
                        Thread newThread = new Thread(DoWork);
                        newThread.Start(i);
                    }
        
                    Console.ReadLine();
                }
        
                static object gObject= new object();
                public static void DoWork(object data)
                {
                    int len = (int)data % 3;
                    object tmp = new object();
                    Console.WriteLine("to lock...... Data='{0}'  sleepTime:{1}", data, len);
                    lock (tmp)//tmp won't work, change tmp to gObject to see different output, which is good locking case)
                    {
                        Console.WriteLine("in lock...... Data='{0}'  sleepTime:{1}", data, len);
                        
                        Thread.Sleep(  len* 1000);
                        Console.WriteLine("Static thread procedure. Data='{0}'  sleepTime:{1}", data, len);
                    }
                }
        
            }
        }
