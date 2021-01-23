    class Watcher
    {
        DateTime start;
        DateTime endTime;
        List<KeyValuePair<DateTime, string>> times = new List<KeyValuePair<DateTime, string>>();
        public Watcher()
        {
            start = DateTime.Now;
            times.Add(new KeyValuePair<DateTime, string>(start, "start"));
            endTime = start;
        }
        public void Tick(string message)
        {
            times.Add(new KeyValuePair<DateTime, string>(DateTime.Now, message));
        }
        public void End()
        {
            endTime = DateTime.Now;
        }
        public string Result(bool useNewLine = false)
        {
            string result = "";
            if (endTime == start)
                endTime = DateTime.Now;
            var total = (endTime - start).TotalSeconds;
            result = $"Total: {total}s;";
            if (times.Count <2)
                return result + " Not another times.";
            else 
                for(int i=1; i<times.Count; i++)
                {
                    if (useNewLine) result += Environment.NewLine;
                    var time = (times[i].Key - times[i - 1].Key).TotalSeconds;
                    var m = times[i];
                    result += $" {m.Value}: {time}s;";
                }
            return result;
        }
    }
