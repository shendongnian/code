    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Collections;
    using System.Runtime.Remoting.Messaging;
    
    namespace TheadingPool1
    {
        // http://www.c-sharpcorner.com/UploadFile/mgold/QueueInThread11222005232529PM/QueueInThread.aspx
    
        public class ThreadQueue
        {
            private Queue _qOrder = new Queue();
            private Queue _qSync;
            private Thread _qThread;
            private ManualResetEvent _eWait = new ManualResetEvent(false);
    
            private int _wait;
    
            public ThreadQueue(int w)
            {
                _wait = w;
                _qSync = Queue.Synchronized(_qOrder);
            }
    
            public void Start()
            {
                _qThread = new Thread(new ThreadStart(Process));
                _qThread.IsBackground = true;
                _qThread.Start();
            }
    
            public void Process()
            {
                Random x = new Random(DateTime.Now.Second);
                object item;
                while (true)
                {
                    item = null;
                    lock (_qSync.SyncRoot)
                    {
                        if (_qSync.Count > 0)
                        {
                            item = (object)_qSync.Dequeue();
                        }
                        else
                        {
                            _eWait.Reset();
                        }
                    }
                    if (item != null)
                    {
                        Console.WriteLine("[" + _wait + "] [" + item.ToString() + "] :D");
                        Thread.Sleep(_wait * x.Next(1, 5));
                    }
                    else
                    {
                        _eWait.WaitOne();
                    }
                }
            }
    
            public void Enqueue(object obj)
            {
                _qSync.Enqueue(obj);
                _eWait.Set();
            }
        }
    
        public class Program
        {
            private static ThreadQueue _q1 = new ThreadQueue(10);
            private static ThreadQueue _q2 = new ThreadQueue(50);
    
            public static void Main(string[] args)
            {
                _q1.Start();
                _q2.Start();
    
                for (int i = 0; i < 50; i++)
                    _q1.Enqueue(i);
    
                for (int i = 0; i < 50; i++)
                    _q2.Enqueue(i);
    
                while (true)
                {
                    Thread.Sleep(100);
                }
            }
        }
    }
