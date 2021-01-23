     using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    class Program
    {
        static void Main(string[] args)
        {
            Class1 c1 = new Class1();
            Class2 c2 = new Class2();
            Thread t1 = new Thread(c1.DoSomthing);
            Thread t2 = new Thread(c2.DoSomthing);
            t1.Start();
            Thread.Sleep(500);
            t2.Start();
        }
    }
    class Class1
    {
        object m_objSyncLock = new object();
        ManualResetEvent m_objSleep = new ManualResetEvent(true);
        public void DoSomthing()
        {
            Monitor.Enter(m_objSyncLock);
                int i = 1;
                 Thread.Sleep(565);
                i++; 
            Monitor.Exit(m_objSyncLock);
            }
        }
    }
    class Class2
    {
        object m_objSyncLock = new object();
        public void DoSomthing()
        {
            lock (m_objSyncLock)
            {
                int i = 1;               
                i++;
            }
        }
    }
