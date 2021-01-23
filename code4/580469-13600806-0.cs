    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication
    {
        public static class ThreadExtensions
        {
            /// <summary>
            /// Blocks the current thread for a period of time so that the thread cannot be reused by the threadpool.
            /// </summary>
            public static void Block(this Thread thread, int millisecondsTimeout)
            {
                new WakeSleepClass(millisecondsTimeout).SleepThread();
            }
    
            /// <summary>
            /// Blocks the current thread so that the thread cannot be reused by the threadpool.
            /// </summary>
            public static void Block(this Thread thread)
            {
                new WakeSleepClass().SleepThread();
            }
    
            /// <summary>
            /// Blocks the current thread for a period of time so that the thread cannot be reused by the threadpool.
            /// </summary>
            public static void Block(this Thread thread, TimeSpan timeout)
            {
                new WakeSleepClass(timeout).SleepThread();
            }
    
            class WakeSleepClass
            {
                bool locked = true;
                readonly TimerDisposer timerDisposer = new TimerDisposer();
    
                public WakeSleepClass(int sleepTime)
                {
                    var timer = new Timer(WakeThread, timerDisposer, sleepTime, sleepTime);
                    timerDisposer.InternalTimer = timer;
                }
    
                public WakeSleepClass(TimeSpan sleepTime)
                {
                    var timer = new Timer(WakeThread, timerDisposer, sleepTime, sleepTime);
                    timerDisposer.InternalTimer = timer;
                }
    
                public WakeSleepClass()
                {
                    var timer = new Timer(WakeThread, timerDisposer, Timeout.Infinite, Timeout.Infinite);
                    timerDisposer.InternalTimer = timer;
                }
    
                public void SleepThread()
                {
                    while (locked)
                        lock (timerDisposer) Monitor.Wait(timerDisposer);
                    locked = true;
                }
    
                public void WakeThread(object key)
                {
                    locked = false;
                    lock (key) Monitor.Pulse(key);
                    ((TimerDisposer)key).InternalTimer.Dispose();
                }
    
                class TimerDisposer
                {
                    public Timer InternalTimer { get; set; }
                }
            }
        }
    
        class Program
        {
            private static readonly Queue<CancellationTokenSource> tokenSourceQueue = new Queue<CancellationTokenSource>();
            static void Main(string[] args)
            {
                CancellationTokenSource tokenSource = new CancellationTokenSource();
                tokenSourceQueue.Enqueue(tokenSource);
    
                ConcurrentDictionary<int, int> startedThreads = new ConcurrentDictionary<int, int>();
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(1000);
                    Task.Factory.StartNew(() =>
                    {
                        startedThreads.AddOrUpdate(Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.ManagedThreadId, (a, b) => b);
                        for (int j = 0; j < 50; j++)
                            Task.Factory.StartNew(() => startedThreads.AddOrUpdate(Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.ManagedThreadId, (a, b) => b));
    
                        for (int j = 0; j < 50; j++)
                        {
                            Task.Factory.StartNew(() =>
                            {
                                while (!tokenSource.Token.IsCancellationRequested)
                                {
                                    if (startedThreads.ContainsKey(Thread.CurrentThread.ManagedThreadId)) Console.WriteLine("Thread reused");
                                    Thread.CurrentThread.Block(10);
                                    if (startedThreads.ContainsKey(Thread.CurrentThread.ManagedThreadId)) Console.WriteLine("Thread reused");
                                }
                            }, tokenSource.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default)
                            .ContinueWith(task =>
                            {
                                WriteExceptions(task.Exception);
                                Console.WriteLine("-----------------------------");
                            }, TaskContinuationOptions.OnlyOnFaulted);
                        }
                        Thread.CurrentThread.Block();
                    }, tokenSource.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default)
                    .ContinueWith(task =>
                    {
                        WriteExceptions(task.Exception);
                        Console.WriteLine("-----------------------------");
                    }, TaskContinuationOptions.OnlyOnFaulted);
                }
    
                Console.Read();
            }
    
            private static void WriteExceptions(Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (ex.InnerException != null)
                    WriteExceptions(ex.InnerException);
            }
        }
    }
