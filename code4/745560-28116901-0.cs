    public class PolyStopwatch
    {
        readonly Dictionary<string, long> counters;
    
        readonly Stopwatch stopwatch;
    
        string currentLabel;
    
        public PolyStopwatch()
        {
            stopwatch = new Stopwatch();
            counters = new Dictionary<string, long>();
        }
    
        public void Start(string label)
        {
            if (currentLabel != null) Stop();
    
            currentLabel = label;
            if (!counters.ContainsKey(label))
                counters.Add(label, 0);
            stopwatch.Restart();
        }
    
        public void Stop()
        {
            if (currentLabel == null)
                throw new InvalidOperationException("No counter started");
    
            stopwatch.Stop();
            counters[currentLabel] += stopwatch.ElapsedMilliseconds;
            currentLabel = null;
        }
    
        public void Print()
        {
            if (currentLabel != null) Stop();
            long totalTime = counters.Values.Sum();
            foreach (KeyValuePair<string, long> kvp in counters)
                Debug.Print("{0,-40}: {1,8:N0} ms ({2:P})", kvp.Key, kvp.Value, (double) kvp.Value / totalTime);
            Debug.WriteLine(new string('-', 62));
            Debug.Print("{0,-40}: {1,8:N0} ms", "Total time", totalTime);
        }
    }
