    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace TasksExample
    {
        class Program
        {
            static void Main(string[] args)
            {
                // holds all the tasks you're trying to run
                List<Task> waitingTasks = new List<Task>();
                
                // a simple object to lock on
                object padlock = new object();
    
                // simple shared value that each task can access
                int sharedValue = 1;
    
                // add each new task to the list above.  The best way to create a task is to use the Task.Factory.StartNew() method.
                // you can also use Task.Factory<RETURNVALUE>.StartNew() method to return a value from the task
                waitingTasks.Add(Task.Factory.StartNew(() => 
                {
                    // this makes sure that we don't enter a race condition when trying to access the
                    // shared value
                    lock (padlock)
                    {
                        // note how we don't need to explicitly pass the sharedValue to the task, it's automatically available
                        Console.WriteLine("I am thread 1 and the shared value is {0}.", sharedValue++);
                    }
                }));
    
                waitingTasks.Add(Task.Factory.StartNew(() => 
                {
                    lock (padlock)
                    {
                        Console.WriteLine("I am thread 2 and the shared value is {0}.", sharedValue++);
                    }
                }));
    
                waitingTasks.Add(Task.Factory.StartNew(() => 
                {
                    lock (padlock)
                    {
                        Console.WriteLine("I am thread 3 and the shared value is {0}.", sharedValue++);
                    }
                }));
    
                waitingTasks.Add(Task.Factory.StartNew(() => 
                {
                    lock (padlock)
                    {
                        Console.WriteLine("I am thread 4 and the shared value is {0}.", sharedValue++);
                    }
                }));
    
                waitingTasks.Add(Task.Factory.StartNew(() => 
                {
                    lock (padlock)
                    {
                        Console.WriteLine("I am thread 5 and the shared value is {0}.", sharedValue++);
                    }
                }));
    
                waitingTasks.Add(Task.Factory.StartNew(() => 
                {
                    lock (padlock)
                    {
                        Console.WriteLine("I am thread 6 and the shared value is {0}.", sharedValue++);
                    }
                }));
    
    
                // once you've spun up all the tasks, pass an array of the tasks to Task.WaitAll, and it will
                // block until all tasks are complete
                Task.WaitAll(waitingTasks.ToArray());
    
                Console.WriteLine("Hit any key to continue...");
                Console.ReadKey(true);
            }
        }
    }
