    /// <summary>Extension methods for timing out tasks</summary>
    public static class TaskExtensions
    {
        /// <summary> throws an error if task does not complete before the timer.</summary>
        public static async Task Timeout(this Task t, Task timer)
        {
            var any = await Task.WhenAny(t, timer);
            if (any != t)
            {
               throw new TimeoutException("task timed out");
            }
        }
        /// <summary> throws an error if task does not complete before the timer.</summary>
        public static async Task<T> Timeout<T>(this Task<T> t, Task timer)
        {
            await Timeout((Task)t, timer);
            return t.Result;
        }
        /// <summary> throws an error if task does not complete in time.</summary>
        public static Task Timeout(this Task t, TimeSpan delay)
        {
            return t.IsCompleted ? t : Timeout(t, Task.Delay(delay));
        }
        /// <summary> throws an error if task does not complete in time.</summary>
        public static Task<T> Timeout<T>(this Task<T> t, TimeSpan delay)
        {
            return Timeout((Task)t, delay);
        }
    }
    // .. elsewhere ..
    public async Task<string> DoWorkInParallel()
    {
        var timer = Task.Delay(TimeSpan.FromMilliseconds(200));
        var alphaTask = Task.Run(() => 4);
        var betaTask = Task.Run(() => true);
        // wait for one of the tasks to complete
        var t = await Task.WhenAny(alphaTask, betaTask).Timeout(timer);
        // exit early if the task produced an invalid result
        if ((t == alphaTask && alphaTask.Result != 5) ||
            (t == betaTask && !betaTask.Result)) return "Nothing";
        // wait for the other task to complete
        // could also just write: await Task.WhenAll(alphaTask, betaTask).Timeout(timer);
        await ((t == alphaTask) ? (Task)betaTask : (Task)alphaTask).Timeout(timer);
        // unfortunately need to repeat the validation logic here.
        // this logic could be moved to a helper method that is just called in both places.
        var alpha = alphaTask.Result;
        var beta = betaTask.Result;
        return (alpha != 5 && beta) ? (alpha.ToString() + beta.ToString()) : "Nothing";
    }
    public async Task<string> DoWorkInSequence()
    {
        var timer = Task.Delay(TimeSpan.FromMilliseconds(200));
        var alpha = await Task.Run(() => 4).Timeout(timer);
        if (alpha != 5)
        {
            var beta = await Task.Run(() => true).Timeout(timer);
            if (beta)
            {
                return alpha.ToString() + beta.ToString();
            }
        }
        return "Nothing";
    }
