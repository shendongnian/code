    using System;
    using System.Collections.Generic;
    using System.Threading;
    
    namespace Demo
    {
        class Program
        {
            static Queue<Worker> waitingWorkers = new Queue<Worker>();
            static Dictionary<int, Worker> activeWorkers = new Dictionary<int, Worker>();
            static int maxThreads = 10;
            static object waitLock = new object();
    
            static void Main(string[] args)
            {
                for (int i = 0; i < 100; i++)
                {
                    waitingWorkers.Enqueue(new Worker(new WorkerDoneDelegate(WorkerDone)));
                }
    
                lock (waitLock)
                {
                    while (waitingWorkers.Count > 0)
                    {
                        if (activeWorkers.Count > maxThreads)
                        {
                            Monitor.Wait(waitLock);
                        }
                        Worker worker = waitingWorkers.Dequeue();
                        Thread thread = new Thread(worker.SendSomething);
                        thread.IsBackground = true;
                        activeWorkers[thread.ManagedThreadId] = worker;
                        thread.Start();
                    }
                }
                Console.WriteLine("Queue empty");
                Console.ReadKey();
            }
    
            static void WorkerDone()
            {
                lock (waitLock)
                {
                    activeWorkers.Remove(Thread.CurrentThread.ManagedThreadId);
                    Console.WriteLine("Worker done - id=" + Thread.CurrentThread.ManagedThreadId.ToString());
                    Monitor.Pulse(waitLock);
                }
            }
    
            public delegate void WorkerDoneDelegate();
            public class Worker
            {
                static Random rnd = new Random();
                
                WorkerDoneDelegate Done;
                
                public Worker(WorkerDoneDelegate workerDoneArg)
                {
                    Done = workerDoneArg;
                }
    
                public void SendSomething()
                {
                    Console.WriteLine("Worker send - id=" + Thread.CurrentThread.ManagedThreadId.ToString());
                    Thread.Sleep(rnd.Next(1, 1000));
                    Done();
                }
            }
        }
    }
