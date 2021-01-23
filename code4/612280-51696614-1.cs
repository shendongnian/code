    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace AsyncAwaitDemo
    {
        class Program
        {
            public static async void AsynchronousOperation()
            {
                Console.WriteLine("Inside AsynchronousOperation Before AsyncMethod, Thread Id: " + Thread.CurrentThread.ManagedThreadId);
                //Task<int> _task = AsyncMethod();
                int count = await AsyncMethod();
    
                Console.WriteLine("Inside AsynchronousOperation After AsyncMethod Before Await, Thread Id: " + Thread.CurrentThread.ManagedThreadId);
    
                //int count = await _task;
    
                Console.WriteLine("Inside AsynchronousOperation After AsyncMethod After Await Before DependentMethod, Thread Id: " + Thread.CurrentThread.ManagedThreadId);
    
                DependentMethod(count);
    
                Console.WriteLine("Inside AsynchronousOperation After AsyncMethod After Await After DependentMethod, Thread Id: " + Thread.CurrentThread.ManagedThreadId);
            }
    
            public static async Task<int> AsyncMethod()
            {
                Console.WriteLine("Inside AsyncMethod, Thread Id: " + Thread.CurrentThread.ManagedThreadId);
                int count = 0;
    
                await Task.Run(() =>
                {
                    Console.WriteLine("Executing a long running task which takes 10 seconds to complete, Thread Id: " + Thread.CurrentThread.ManagedThreadId);
                    Thread.Sleep(20000);
                    count = 10;
                });
    
                Console.WriteLine("Completed AsyncMethod, Thread Id: " + Thread.CurrentThread.ManagedThreadId);
    
                return count;
            }       
    
            public static void DependentMethod(int count)
            {
                Console.WriteLine("Inside DependentMethod, Thread Id: " + Thread.CurrentThread.ManagedThreadId + ". Total count is " + count);
            }
    
            static void Main(string[] args)
            {
                Console.WriteLine("Started Main method, Thread Id: " + Thread.CurrentThread.ManagedThreadId);
    
                AsynchronousOperation();
    
                Console.WriteLine("Completed Main method, Thread Id: " + Thread.CurrentThread.ManagedThreadId);
    
                Console.ReadKey();
            }
    
        }
    }
