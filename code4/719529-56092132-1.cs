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
            var CreatedAndNotLocked = Created.RetryIf(IsFileLocked, att => (att - 1) * 100, Scheduler.Default);
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
        public static IObservable<T> RetryIf<T>(
            this IObservable<T> source, Func<T, bool> predicate, Func<int> delayProvider, IScheduler scheduler)
        {
            return source.SelectMany(x => RetryIf(x, predicate, delayProvider, scheduler));
        }
        public static IObservable<T> RetryIf<T>(
            this IObservable<T> source, Func<T, bool> predicate, Func<int, int> delay, IScheduler scheduler)
        {
            int attempt = 0;
            return source.SelectMany(x => RetryIf(x, predicate, () => delay.Invoke(++attempt), scheduler));
        }
        public static IObservable<T> RetryIf<T>(
            this IObservable<T> source, Func<T, bool> predicate, IEnumerator<int> delay, IScheduler scheduler)
        {
            Func<int> fdelay = () =>
            {
                var r = delay.Current;
                delay.MoveNext();
                return r;
            }; return source.SelectMany(x => RetryIf(x, predicate, fdelay, scheduler));
        }
        private static IObservable<T> RetryIf<T>(T item, Func<T, bool> predicate, Func<int> delayProvider, IScheduler scheduler)
        {
            var source = Observable.Defer(() => Observable.Return(item));
            int delay;
            return Observable.Defer(() =>
           ((delay = delayProvider.Invoke()) == 0 ? source : source.DelaySubscription(TimeSpan.FromMilliseconds(delay), scheduler))
                 .SelectMany(it => predicate.Invoke(it)
                     ? Observable.Throw<T>(new Exception(it + " retry "))
                     : Observable.Return(item))
            )
            .Retry();
        }
    }
