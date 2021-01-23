    public static class AtomicHelper
    {
        public static void LongTransaction(
            object obj,
            TimeSpan pollInterval,
            ref long value,
            Func<long, bool> precondition,
            Func<long, long> transform,
            Func<long, bool> postcondition)
        {
            while (true)
            {
                var oldValue = Interlocked.Read(ref value);
                if (precondition != null && !precondition(oldValue))
                {
                    Monitor.Wait(obj, pollInterval);
                    continue;
                }
                var newValue = transform(oldValue);
                if (postcondition != null && !postcondition(newValue))
                {
                    Monitor.Wait(obj, pollInterval);
                    continue;
                }
                if (Interlocked.CompareExchange(ref value, newValue, oldValue) == oldValue)
                {
                    Monitor.PulseAll(obj);
                    return;
                }
            }
        }
    }
