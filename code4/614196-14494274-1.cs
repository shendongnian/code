     using System.Threading;
     using System.Threading.Tasks;
     List<Task> tasks = new List<Task>();
     foreach(item in listItem)
     {
           tasks.Add(Task.Factory.StartNew(() => aaa()));
     }
    // If you want the Console.Writeline to execute immediately after starting the tasks
    Console.Writeline();            
    Task.WaitAll(tasks.ToArray());
    Console.Writeline("Finised executing all tasks");
