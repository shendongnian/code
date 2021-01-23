        using System;
        using System.Collections.Generic;
        using System.Threading;
        using System.Threading.Tasks;
        namespace ConsoleApplication2
        {
            internal class Program
            {
                private static void Main(string[] args)
                {
                    CancellationTokenSource cancelSource = new CancellationTokenSource();
                    Console.WriteLine("Press any key to interrupt the work.");
                    var work = Task<bool>.Factory.StartNew(() => test(cancelSource.Token));
                    Console.ReadKey();
                    cancelSource.Cancel();
                    Console.WriteLine(work.Result ? "Completed." : "Interrupted.");
                }
                private static bool test(CancellationToken cancelToken)
                {
                    return new List<Action> 
                    { 
                        doTask1,
                        doTask2,
                        doTask3,
                        doTask4,
                        () => Console.WriteLine("Press a key to exit.")
                    }
                    .Run(cancelToken);
                }
                private static void doTask1()
                {
                    Console.WriteLine("Task 1 Working...");
                    Thread.Sleep(1000);
                    Console.WriteLine("...did some work.");
                }
                private static void doTask2()
                {
                    Console.WriteLine("Task 2 Working...");
                    Thread.Sleep(1000);
                    Console.WriteLine("...did some work.");
                }
                private static void doTask3()
                {
                    Console.WriteLine("Task 3 Working...");
                    Thread.Sleep(1000);
                    Console.WriteLine("...did some work.");
                }
                private static void doTask4()
                {
                    Console.WriteLine("Task 4 Working...");
                    Thread.Sleep(1000);
                    Console.WriteLine("...did some work.");
                }
            }
            public static class EnumerableActionExt
            {
                public static bool Run(this IEnumerable<Action> actions, CancellationToken cancelToken)
                {
                    foreach (var action in actions)
                    {
                        if (!cancelToken.IsCancellationRequested)
                        {
                            action();
                        }
                        else
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
        }
