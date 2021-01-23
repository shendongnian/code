    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace Edit4Posting
    {
    public class Node
    {
      
      public Node Previous { get; private set; }
      public Node(Node previous)
      {
        Previous = previous;
        }
      }
      public class Edit4Posting
      {
        
        public static void Main(string[] args)
        {
          int concurrentThreads = 0;
          int directThreadsCount = 0;
          int diagThreadCount = 0;
    
          var jobs = Enumerable.Range(0, 160);
          ParallelOptions po = new ParallelOptions
          {
            MaxDegreeOfParallelism = Environment.ProcessorCount
          };
          Parallel.ForEach(jobs, po, delegate(int jobNr)
          //Parallel.ForEach(jobs, delegate(int jobNr)
          {
            int threadsRemaining = Interlocked.Increment(ref concurrentThreads);
    
            int heavyness = jobNr % 9;
    
            //Give the processor and the garbage collector something to do...
            List<Node> nodes = new List<Node>();
            Node current = null;
            //for (int y = 0; y < 1024 * 1024 * heavyness; y++)
            for (int y = 0; y < 1024 * 24 * heavyness; y++)
            {
              current = new Node(current);
              nodes.Add(current);
            }
            //*******************************
            directThreadsCount = Process.GetCurrentProcess().Threads.Count;
            //*******************************
            threadsRemaining = Interlocked.Decrement(ref concurrentThreads);
            Console.WriteLine("[Job {0} complete. {1} threads remaining but directThreadsCount == {2}",
              jobNr, threadsRemaining, directThreadsCount);
          });
          Console.WriteLine("FINISHED");
          Console.ReadLine();
        }
      }
    }
  
