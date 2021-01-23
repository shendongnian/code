    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reactive.Concurrency;
    using System.Reactive.Linq;
    using System.Reactive.Threading.Tasks;
    public class TestWatcher
    {
        public static void Test()
        {
            FileSystemWatcher Watcher = new FileSystemWatcher("C:\\test")
            {
                EnableRaisingEvents = true,
            };
            var Created = Observable
                .FromEventPattern<FileSystemEventHandler, FileSystemEventArgs>(h => Watcher.Created += h, h => Watcher.Created -= h)
                .Select(e => e.EventArgs.FullPath);
            var CreatedAndNotLocked = Created.WaitIf(IsFileLocked,100, attempt =>TimeSpan.FromMilliseconds(100), Scheduler.Default);
            var FirstCreatedAndNotLocked = CreatedAndNotLocked.Take(1)
                .Finally(Watcher.Dispose);
            var task = FirstCreatedAndNotLocked.GetAwaiter().ToTask();
            task.Wait();
            Console.WriteLine(task.Result);
        }
        public bool IsFileLocked(string filePath)
        {
            var ret = false;
            try
            {
                using (File.Open(filePath, FileMode.Open)) { }
            }
            catch (IOException e)
            {
                var errorCode = Marshal.GetHRForException(e) & ((1 << 16) - 1);
                ret = errorCode == 32 || errorCode == 33;
            }
            return ret;
        }
    }
    public static class ObservableExtensions
    {
        public class FakeException : Exception
        {
            public FakeException(string message) : base(message)
            {
            }
        }
        public static IObservable<T> WaitIf<T>(
          this IObservable<T> @this,
          Func<T, bool> predicate,
          int? retryCount = null,
          Func<int, TimeSpan> strategy = null,
          IScheduler scheduler = null)
        {
            return @this.SelectMany(f =>
            Observable.Defer(() =>
             predicate(f) ?
                   Observable.Throw<T>(new FakeException(f+" not ready"))) :
                   Observable.Return(f)
           ).RetryWithBackoff(retryCount, strategy, ex => ex is FakeException));
        }
    }
