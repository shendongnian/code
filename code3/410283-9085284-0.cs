    public class Recurrence
    {
        public int Id { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public DateTime? EndDate { get; protected set; }
        public long? RecurrenceInterval { get; protected set; }
        // returns the set of DateTimes within [subStart, subEnd] that are
        // of the form StartDate + k*RecurrenceInterval, where k is an Integer
        public IEnumerable<DateTime> GetBetween(DateTime subStart, DateTime subEnd)
        {            
            long stride = RecurrenceInterval ?? 1;
            if (stride < 1) 
                throw new ArgumentException("Need a positive recurrence stride");
                
            long realStart, realEnd;
            // figure out where we really need to start
            if (StartDate >= subStart)
                realStart = StartDate.Ticks;
            else
            {
                long rem = subStart.Ticks % stride;
                if (rem == 0)
                    realStart = subStart.Ticks;
                else
                    realStart = subStart.Ticks - rem + stride;
            }
            // figure out where we really need to stop
            if (EndDate <= subEnd)
                // we know EndDate has a value. Null can't be "less than" something
                realEnd = EndDate.Value.Ticks; 
            else
            {
                long rem = subEnd.Ticks % stride;
                // break off any incomplete stride
                realEnd = subEnd.Ticks - rem;
            }
            if (realEnd < realStart)
                yield break; // the intersection is empty
            // now yield all the results in the intersection of the sets
            for (long t = realStart; t <= realEnd; t += stride)
                yield return new DateTime(t);
        }
    }
