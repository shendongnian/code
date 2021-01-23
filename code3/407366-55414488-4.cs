    namespace CLRTest
    {
        using System;
        using System.Collections.Concurrent;
        using System.Diagnostics;
        using System.Globalization;
        using System.Linq;
        using System.Runtime.Caching;
    
        class Program
        {
            static void Main(string[] args)
            {
                CacheTester.TestCache();
            }
        }
    
        public class SignaledChangeEventArgs : EventArgs
        {
            public string Name { get; private set; }
            public SignaledChangeEventArgs(string name = null) { this.Name = name; }
        }
    
        /// <summary>
        /// Cache change monitor that allows an app to fire a change notification
        /// to all associated cache items.
        /// </summary>
        public class SignaledChangeMonitor : ChangeMonitor
        {
            // Shared across all SignaledChangeMonitors in the AppDomain
            private static ConcurrentDictionary<string, EventHandler<SignaledChangeEventArgs>> ListenerLookup = 
                new ConcurrentDictionary<string, EventHandler<SignaledChangeEventArgs>>();
    
            private string _name;
            private string _key;
            private string _uniqueId = Guid.NewGuid().ToString("N", CultureInfo.InvariantCulture);
    
            public override string UniqueId
            {
                get { return _uniqueId; }
            }
    
            public SignaledChangeMonitor(string key, string name)
            {
                _key = key;
                _name = name;
                // Register instance with the shared event
                ListenerLookup[_uniqueId] = OnSignalRaised;
                base.InitializationComplete();
            }
    
            public static void Signal(string name = null)
            {
                // Raise shared event to notify all subscribers
                foreach (var subscriber in ListenerLookup.ToList())
                {
                    subscriber.Value?.Invoke(null, new SignaledChangeEventArgs(name));
                }
            }
    
            protected override void Dispose(bool disposing)
            {
                // Set delegate to null so it can't be accidentally called in Signal() while being disposed
                ListenerLookup[_uniqueId] = null;
                EventHandler<SignaledChangeEventArgs> outValue = null;
                ListenerLookup.TryRemove(_uniqueId, out outValue);
            }
    
            private void OnSignalRaised(object sender, SignaledChangeEventArgs e)
            {
                if (string.IsNullOrWhiteSpace(e.Name) || string.Compare(e.Name, _name, true) == 0)
                {
                    // Cache objects are obligated to remove entry upon change notification.
                    base.OnChanged(null);
                }
            }
        }
    
        public static class CacheTester
        {
            private static Stopwatch _timer = new Stopwatch();
    
            public static void TestCache()
            {
                MemoryCache cache = MemoryCache.Default;
                int size = (int)1e6;
    
                Start();
                for (int idx = 0; idx < size; idx++)
                {
                    cache.Add(idx.ToString(), "Value" + idx.ToString(), GetPolicy(idx, cache));
                }
                long prevCnt = cache.GetCount();
                Stop($"Added    {prevCnt} items");
    
                Start();
                SignaledChangeMonitor.Signal("NamedData");
                Stop($"Removed  {prevCnt - cache.GetCount()} entries");
                prevCnt = cache.GetCount();
    
                Start();
                SignaledChangeMonitor.Signal();
                Stop($"Removed  {prevCnt - cache.GetCount()} entries");
            }
    
            private static CacheItemPolicy GetPolicy(int idx, MemoryCache cache)
            {
                string name = (idx % 10 == 0) ? "NamedData" : null;
    
                CacheItemPolicy cip = new CacheItemPolicy();
                cip.AbsoluteExpiration = System.DateTimeOffset.UtcNow.AddHours(1);
                var monitor = new SignaledChangeMonitor(idx.ToString(), name);
                cip.ChangeMonitors.Add(monitor);
                return cip;
            }
    
            private static void Start()
            {
                _timer.Start();
            }
    
            private static void Stop(string msg = null)
            {
                _timer.Stop();
                Console.WriteLine($"{msg} | {_timer.Elapsed.TotalSeconds} sec");
                _timer.Reset();
            }
        }
    }
