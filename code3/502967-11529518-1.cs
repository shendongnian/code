    void Main()
    {
        // Insert code here to set up your test: anything that you don't want to include as
        // part of the timed tests.
        var dict = new Dictionary<int, string>();
        for (int i = 0; i < 2000; i++)
            dict[i] = "test " + i;
        string s = null;
        var actions = new[]
        {
    	    new TimedAction("control", () => 
            {
        for (int i = 0; i < 2000; i++)
                s = "hi";
            }),
    	    new TimedAction("first", () => 
            {
                foreach (var pair in dict)
                s = pair.Value;
            }),
            new TimedAction("second", () => 
            {
                foreach (var key in dict.Keys)
                s = dict[key];
            })
        };
        TimeActions(100, // change this number as desired.
            actions);
    }
    
    
    #region timer helper methods
    // Define other methods and classes here
    public void TimeActions(int iterations, params TimedAction[] actions)
    {
        Stopwatch s = new Stopwatch();
        foreach(var action in actions)
        {
            var milliseconds = s.Time(action.Action, iterations);
            Console.WriteLine("{0}: {1}ms ", action.Message, milliseconds);
        }
    
    }
    
    public class TimedAction
    {
        public TimedAction(string message, Action action)
        {
            Message = message;
            Action = action;
        }
        public string Message {get;private set;}
        public Action Action {get;private set;}
    }
    
    public static class StopwatchExtensions
    {
        public static double Time(this Stopwatch sw, Action action, int iterations)
        {
            sw.Restart(); 
            for (int i = 0; i < iterations; i++)
            {
                action();
            }
            sw.Stop();
    
            return sw.Elapsed.TotalMilliseconds;
        }
    }
    #endregion
