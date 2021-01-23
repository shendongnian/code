    /// <summary>Extension methods for timing out tasks</summary>
    public static class TaskExtensions
    {
        /// <summary> throws an error if task does not complete in time.</summary>
        private async Task Timeout(this Task t, TimeSpan delay)
        {
            var any = await Task.WhenAny(t, Task.Delay(delay));
            if (any != t)
            {
               throw new TimeoutException("task timed out");
            }
        }
        /// <summary> throws an error if task does not complete in time.</summary>
        private async Task<T> Timeout<T>(this Task<T> t, TimeSpan delay)
        {
            await Timeout((Task)t, delay);
            return t.Result;
        }
    }
    // .. elsewhere ..
    public async Task<string> DoWorkInParallel()
    {
        var alphaTask = Task.Run(() => 4);
        var betaTask = Task.Run(() => true);
        await Task.WhenAll(alphaTask, betaTask).Timeout(TimeSpan.FromMilliseconds(200));
        var alpha = alphaTask.Result;
        var beta = betaTask.Result;
        return (alpha != 5 && beta) ? (alpha.ToString() + beta.ToString()) : "Nothing";
    }
    public async Task<string> DoWorkInSequence()
    {
        var alpha = await Task.Run(() => 4).Timeout(TimeSpan.FromMilliseconds(200));
        if (alpha != 5)
        {
            var beta = await Task.Run(() => true).Timeout(TimeSpan.FromMilliseconds(200));
            if (beta)
            {
                return alpha.ToString() + beta.ToString();
            }
        }
        return "Nothing";
    }
