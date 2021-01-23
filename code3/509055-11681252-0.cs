    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    namespace ConsoleApplication5
    {
        class Program
        {
            public static readonly int numOfTasks = 100;
            public static int numTasksLeft = numOfTasks;
            public static readonly object TaskDecrementLock = new object();
            static void Main(string[] args)
            {
                DoRead dr = new DoRead();
                dr.StartReading();
                int tmpNumTasks = numTasksLeft;
                while ( tmpNumTasks > 0 )
                {
                    Thread.Sleep(1000);
                    tmpNumTasks = numTasksLeft;
                }
                List<string> strings = new List<string>();
                lock( DoRead.locker )
                {
                    for (int i = 1; i <= Program.numOfTasks; i++)
                    {
                        strings.Add( DoRead.dicto[i] );
                    }
                }
                foreach (string s in strings)
                {
                    Console.WriteLine(s);
                }
                Console.ReadLine();
            }
            public class DoRead
            {
                public static readonly object locker = new object();
                public static Dictionary<int, string> dicto = new Dictionary<int, string>();
                public DoRead()
                {
                }
                public void StartReading()
                {
                    int i = 1;
                    Runner[] runnerArray = new Runner[ Program.numOfTasks + 1 ];
                    while (i <= Program.numOfTasks )
                    {
                        Runner r = new Runner(i, "Work" + i.ToString());
                        runnerArray[i] = r;
                        r.StartThread();
                        i += 1;
                    }
                
                }
            }
            internal class Runner : System.IDisposable
            {
                int _count;
                string _work = "";
                public Runner(int Count, string Work)
                {
                    _count = Count;
                    _work = Work;
                }
                public void StartThread()
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(runThreadInPool), this);
                }
                public static void runThreadInPool(object obj)
                {
                    Runner theRunner = ((Runner)obj);
                    string theString = theRunner.run();
                    lock (DoRead.locker)
                    {
                        DoRead.dicto.Add( theRunner._count, theString);
                    }
                    lock (Program.TaskDecrementLock)
                    {
                        Program.numTasksLeft--;
                    }
                }
                public string run()
                {
                    try
                    {
                        Random r = new Random();
                        int num = r.Next(1000, 2000);
                        Thread.Sleep(num);
                        string theString = _count.ToString() + " : Done!";
                        return theString;
                    }
                    catch
                    {
                    }
                    finally
                    {
                        _work = null;
                    }
                    return "";
                }
                public void Dispose()
                {
                    this._work = null;
                }
            }
        }
    }
