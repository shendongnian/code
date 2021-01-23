    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NodaTime;
        
    class Test
    {
        static void Main()
        {
            var schedule = new List<TimePeriod>
            {
                new TimePeriod(new LocalTime(7, 30), new LocalTime(12, 0)),
                new TimePeriod(new LocalTime(13, 30), new LocalTime(17, 0)),
            };
    
            var movements = new List<TimePeriod>
            {
                new TimePeriod(new LocalTime(6, 50), new LocalTime(6, 55)),
                new TimePeriod(new LocalTime(7, 0), new LocalTime(11, 45)),
                new TimePeriod(new LocalTime(13, 45), new LocalTime(17, 05))
            };
            
            var durations = from s in schedule
                            from m in movements
                            select s.Intersect(m).Duration;
            var total = durations.Aggregate((current, next) => current + next);
            Console.WriteLine(total);
        }
    }
    
    class TimePeriod
    {
        private readonly LocalTime start;
        private readonly LocalTime end;
        
        public TimePeriod(LocalTime start, LocalTime end)
        {
            if (start > end)
            {
                throw new ArgumentOutOfRangeException("end");
            }
            this.start = start;
            this.end = end;
        }
        
        public LocalTime Start { get { return start; } }
        public LocalTime End { get { return end; } }
        public Duration Duration { get { return Period.Between(start, end)
                                                      .ToDuration(); } }
        
        public TimePeriod Intersect(TimePeriod other)
        {
            // Take the max of the start-times and the min of the end-times
            LocalTime newStart = start > other.start ? start : other.start;
            LocalTime newEnd = end < other.end ? end : other.end;
            // When the two don't actually intersect, just return an empty period.
            // Otherwise, return the appropriate one.
            if (newEnd < newStart)
            {
                newEnd = newStart;
            }
            return new TimePeriod(newStart, newEnd);
        }
    }
