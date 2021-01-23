    using System;
    using System.Diagnostics;
    
    class MainClass
    {
       public static void Main()
       {
          Process[] allProcs = Process.GetProcesses();
    
          foreach(Process proc in allProcs)
          {
             ProcessThreadCollection myThreads = proc.Threads;
             Console.WriteLine("process: {0},  id: {1}", proc.ProcessName, proc.Id);
    
             foreach(ProcessThread pt in myThreads)
             {
                Console.WriteLine("  thread:  {0}", pt.Id);
                Console.WriteLine("    started: {0}", pt.StartTime.ToString());
                Console.WriteLine("    CPU time: {0}", pt.TotalProcessorTime);
                Console.WriteLine("    priority: {0}", pt.BasePriority);
                Console.WriteLine("    thread state: {0}", pt.ThreadState.ToString()); 
             }
          }
       }
    }
