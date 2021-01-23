    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Concurrent;
    
    class App
    {
      static void Main()
      {
        var q = new WorkQueue();
        q.Execute(() => Console.WriteLine("A"));
        q.Execute(() => Console.WriteLine("B"));
        Task<int> t = q.Execute(() => 33);
    
        Console.WriteLine(t.Result);
        q.Dispose();
      }
    
    }
    
    public class WorkQueue : IDisposable
    {
      private readonly Thread thread;
      private readonly BlockingCollection<Action> queue;
      public WorkQueue()
      {
        this.queue = new BlockingCollection<Action>();
        this.thread = new Thread(DoWork);
        this.thread.Start();
      }
    
      public Task<T> Execute<T>(Func<T> f)
      {
        if (this.queue.IsCompleted) return null;
        var source = new TaskCompletionSource<T>();
        Execute(() => source.SetResult(f()));
        return source.Task;
      }
    
      public void Execute(Action f)
      {
        if (this.queue.IsCompleted) return;
        this.queue.Add(f);
      }
    
      public void Dispose()
      {
        this.queue.CompleteAdding();
        this.thread.Join();
      }
    
      private void DoWork()
      {
        foreach (var action in this.queue.GetConsumingEnumerable())
        {
          action();
        }
      }
    }
